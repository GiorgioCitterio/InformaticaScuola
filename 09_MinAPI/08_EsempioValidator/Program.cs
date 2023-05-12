using _08_EsempioValidator.Data;
using _08_EsempioValidator.Model;
using _08_EsempioValidator.Validator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//aggiungo il validatore
//builder.Services.AddScoped<IValidator<Student>, StudentValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Transient);

//connessione al database nel caso di Microsoft SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentDbContext>(option =>
    option.UseSqlServer(connectionString));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/", async (StudentDbContext db) =>
    await db.Students.ToListAsync());

//applico il filtro
app.MapPost("/studentsFilter", async (StudentDbContext db, Student student) =>
{
    await db.Students.AddAsync(student);
    await db.SaveChangesAsync();
    return Results.Created($"/studentsFilter", student);
}).AddEndpointFilter(async (context, next) =>
{
    //recupero lo studente che devo controllare
    Student? studentParam = context.Arguments
        .FirstOrDefault(s => s.GetType() == typeof(Student)) as Student;
    IValidator<Student> validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<Student>>();
    if (validator is not null && studentParam is not null)
    {
        var studValid = validator.Validate(studentParam);
        return Results.ValidationProblem(studValid.ToDictionary(), 
            statusCode: (int)HttpStatusCode.UnprocessableEntity);
    }
    return await (next(context));
});

//applico il validator
app.MapPost("/students", async (StudentDbContext db, Student student, IValidator<Student> validator) =>
{
    var validatorStudents = validator.Validate(student);    
    if (!validatorStudents.IsValid)
        return Results.ValidationProblem(validatorStudents.ToDictionary(), 
           statusCode: (int)HttpStatusCode.UnprocessableEntity);
    await db.Students.AddAsync(student);
    await db.SaveChangesAsync();
    return Results.Created($"/student/{student.StudentId}", student);
});

//da .net 7.0 non bisogna più iniettare il validator nella lambda
string ColorName1(string color) => $"Colore {color}";
string ColorName2(string color1, string color2) => $"Colore 1: {color1}\nColore 2: {color2}";

app.MapGet("/colorselector/{color1}", ColorName1) //aggiunge il filtro
    .AddEndpointFilter(async (context, next) =>
    {
        var color = context.GetArgument<string>(0); //prende il primo argomento che una string e lo salva in color
        if (color.ToLowerInvariant() == "red")
            return Results.Problem("colore non corretto");
        return await (next(context));
    });

app.MapGet("/colorselector/{color1}/selector/{color2}", ColorName2)
    .AddEndpointFilter(async (context, next) =>
    {
        var color1 = context.GetArgument<string>(0);
        var color2 = context.GetArgument<string>(1);
        if (color1.ToLowerInvariant() == "red" || color2.ToLowerInvariant() == "black")
            return Results.Problem("colore non corretto");
        return await (next(context));
    });

app.MapGet("/cascata", () =>
    {
        app.Logger.LogInformation("Endpoint");
        return "Test of multiple filters";
    })
    .AddEndpointFilter(async (efiContext, next) =>
    {
        app.Logger.LogInformation("Before first filter");
        var result = await next(efiContext);
        app.Logger.LogInformation("After first filter");
        return result;
    })
    .AddEndpointFilter(async (efiContext, next) =>
    {
        app.Logger.LogInformation(" Before 2nd filter");
        var result = await next(efiContext);
        app.Logger.LogInformation(" After 2nd filter");
        return result;
    })
    .AddEndpointFilter(async (efiContext, next) =>
    {
        app.Logger.LogInformation("     Before 3rd filter");
        var result = await next(efiContext);
        app.Logger.LogInformation("     After 3rd filter");
        return result;
    });

app.Run();