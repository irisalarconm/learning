using apiweb;
using apiweb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//configurar EF para poder conectar a la BBDD

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareasDbMvC"));//connection string
//TrustServerCertificate = True
//builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));


//antes del build hacer la inyecciond e dependencias
//builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();

builder.Services.AddScoped<IHelloWorldService>(p=>new HelloWorldService()); //así solo se usa cuando se deben pasar parametros
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
