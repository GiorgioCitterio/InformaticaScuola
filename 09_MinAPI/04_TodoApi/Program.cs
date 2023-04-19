using _04_TodoApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//aggiunge il dbcontext
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//connection string per db sqlite
var connectionString = 
    builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=DefaultPizzas.db";
builder.Services.AddDbContext<TodoDb>(options => options.UseSqlite(connectionString));
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

//app.MapGet("/", () => "Hello World!").WithName("HelloWorld").WithOpenApi();

//app.MapGet("/", [Produces("application/json")] () => "Hello World!")
//    .WithName("HelloWorld")
//    .WithOpenApi();

//app.MapGet("/risposta", [Produces("text/plain")][ProducesResponseType(StatusCodes.Status201Created)][ProducesResponseType(StatusCodes.Status400BadRequest)] () => "Hello World!")
//    .WithName("HelloWorld")
//    .WithOpenApi();


//qui metto le api

#region API con percorso completo

//sempre asincrono perchè accedo al db e gli passo sempre l'istanza del db
//metto la rotta, istanza del db
//prendo tutti gli elementi
app.MapGet("/todoitems", async (TodoDb db) => await db.Todos.ToListAsync());

//tutti gli elementi completati
app.MapGet("/todoitems/complete", async (TodoDb db) => 
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

//cerca un elemento per id
//se lo trova restituisce l'elemento se no niente
app.MapGet("todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id) is Todo todo
        ? Results.Ok(todo)
        : Results.NotFound());

//fa la post di un elemento passato
app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
{
    await db.Todos.AddAsync(todo);
    await db.SaveChangesAsync();
    return Results.Created($"todoitems/{todo.Id}", todo);
});

//fa la put di un elemento dato un id e i campi di quell'oggetto da modificare
app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);    
    if(todo is null)
        return Results.NotFound();
    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

//fa la delete di un elemento con un determinato id
app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }
    return Results.NotFound();
});

#endregion

#region API utilizzando rotta predefinita

//var todoItems = app.MapGroup("/todoitems");

//todoItems.MapGet("/", async (TodoDb db) => await db.Todos.ToListAsync());

//todoItems.MapGet("/{id}", async (int id, TodoDb db) =>
//    await db.Todos.FindAsync(id) is Todo todo
//        ? Results.Ok(todo)
//        : Results.NotFound());

#endregion

app.Run();
