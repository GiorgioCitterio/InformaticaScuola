using _04_TodoApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//aggiunge il dbcontext
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.MapGet("/", () => "Hello World!").WithName("HelloWorld").WithOpenApi();

//app.MapGet("/", [Produces("application/json")] () => "Hello World!")
//    .WithName("HelloWorld")
//    .WithOpenApi();

//app.MapGet("/risposta", [Produces("text/plain")][ProducesResponseType(StatusCodes.Status201Created)][ProducesResponseType(StatusCodes.Status400BadRequest)] () => "Hello World!")
//    .WithName("HelloWorld")
//    .WithOpenApi();

//qui metto le api

app.Run();
