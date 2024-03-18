using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

//?Aquí antes de construirse el aplicativo se adiciona el entity framework.

//builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TareasDB")); //USANDO BBDD EN MEMORIA


//Mala practica hacer esto -- appsettings.json para esta configuración por seguridad
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//CREACION MAPEO - creacion de un endpoint para ver si se genera la base de datos en memoria

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

//!----Métodos - EndPoints Tareas----*//


app.MapGet("/api/tareas", async([FromServices] TareasContext dbContext)=>
{
        return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria));
});

app.MapPost("/api/tareas", async([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();

});

app.MapPut("/api/tareas/{id}", async([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id)=>
{

    var tareaActual = dbContext.Tareas.Find(id);

    if(tareaActual != null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }
    
    return Results.NotFound();

});

app.MapDelete("/api/tareas/{id}", async([FromServices] TareasContext dbContext, [FromRoute] Guid id)=>
{
    var tareaActual = dbContext.Tareas.Find(id);

    if(tareaActual != null)
    {
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
        
    }
    
    return Results.NotFound();
});

//!----Métodos - EndPoints Categorias----*//

app.MapGet("/api/categorias", async([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Categorias);
});

app.MapPost("/api/categorias", async([FromServices] TareasContext dbContext, [FromBody] Categoria categoria)=>
{
    categoria.CategoriaId = Guid.NewGuid();
    categoria.Nombre= "Oficio Casa";

    await dbContext.AddAsync(categoria);
    //await dbContext.Categoria.AddAsync(categoria);

    await dbContext.SaveChangesAsync();
    return Results.Ok();
});
app.Run();
