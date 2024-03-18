using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectProductClient.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ProductClientContext>(p=>p.UseInMemoryDatabase("ProductClientDb"));
builder.Services.AddSqlServer<ProductClientContext>(builder.Configuration.GetConnectionString("dbSource"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async([FromServices] ProductClientContext dbContext)=>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("It's working: " + dbContext.Database.IsInMemory());
});

app.MapGet("/clientdata", async([FromServices] ProductClientContext dbContext)=>
{
    return Results.Ok(dbContext.Clients);
});

app.MapGet("/products", async([FromServices] ProductClientContext dbContext)=>
{
    return Results.Ok(dbContext.Products.Include(p=>p.Client));
});


app.Run();
