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
builder.Services.AddScoped<IValidator<Student>, StudentValidator>();

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

app.Run();