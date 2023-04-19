using Microsoft.EntityFrameworkCore;
using _06_TodoApiDTO.Data;
using _06_TodoApiDTO.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

RouteGroupBuilder todoItems = app.MapGroup("/todoitems");

todoItems.MapGet("/", async (TodoDb db)=>
{
    await db.Todos.Select(s => new TodoItemDTO(s)).ToArrayAsync();
    //await db.Todos.ForEachAsync(s => new TodoItemDTO(s));
});

todoItems.MapPost("/", async (TodoItemDTO todoItemDTO, TodoDb db) =>
{
    Todo todo = new() { Name = todoItemDTO.Name, IsComplete = todoItemDTO.IsComplete };
    await db.Todos.AddAsync(todo);
    await db.SaveChangesAsync();
    todoItemDTO = new(todo);
    return Results.Created($"todoitems/{todo.Id}", todoItemDTO);
});

app.Run();