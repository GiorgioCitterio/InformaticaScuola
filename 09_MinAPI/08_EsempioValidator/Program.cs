using _08_EsempioValidator.Data;
using _08_EsempioValidator.Model;
using _08_EsempioValidator.Validator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

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

app.Run();