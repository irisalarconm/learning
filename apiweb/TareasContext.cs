using Microsoft.EntityFrameworkCore;
using apiweb.Models;

namespace apiweb;

//Esta clase contiene la relación de los modelos de app. Esto se vuelve en colecciones que luego son llevados a la BBDD.
// Generalmente se llama como el aplicativo o negocio + la palabra Context ::: TareasContext

public class TareasContext: DbContext
{
    //creacion del dbset => set de datos del modelo que se creo --- seria una tabla en el contexto de EF

    public DbSet<Categoria> Categorias {get;set;} //se llaman plural y los modelos en singular
    public DbSet<Tarea> Tareas {get;set;}

    //metodo base del constructor
    public TareasContext(DbContextOptions<TareasContext> options) :base(options){ }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria(){CategoriaId= Guid.Parse("8277b440-2ce3-43d7-ab19-9e7bb732bc2d"), 
        Nombre = "Actividades Pendientes", Peso = 20}); 
        categoriasInit.Add(new Categoria(){CategoriaId= Guid.Parse("8277b440-2ce3-43d7-ab19-9e7bb732bc02"), 
        Nombre = "Actividades Personales", Peso = 50}); 
        //Guid.NewGuid() Este metodo genera un id pero cambia cada vez que EF haga los cambios. No se recomienda.
        //Guid generator en google


        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria"); //tablas en singular
            categoria.HasKey(p=>p.CategoriaId);
            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=>p.Descripcion).IsRequired(false);
            categoria.Property(p=>p.Peso);
            categoria.HasData(categoriasInit);

        });


        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea(){TareaId = Guid.Parse("8277b440-2ce3-43d7-ab19-9e7bb732bc10"), CategoriaId = Guid.Parse("8277b440-2ce3-43d7-ab19-9e7bb732bc2d"), 
        PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios públicos", FechaCreacion = DateTime.Now}); 
        tareasInit.Add(new Tarea(){TareaId = Guid.Parse("8277b440-2ce3-43d7-ab19-9e7bb732bc11"), CategoriaId = Guid.Parse("8277b440-2ce3-43d7-ab19-9e7bb732bc02"), 
        PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver el documental", FechaCreacion = DateTime.Now}); 

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=>p.TareaId);
            tarea.HasOne(p=>p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaId);
            tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=>p.Descripcion).IsRequired(false);
            tarea.Property(p=>p.FechaCreacion);
            tarea.Property(p=>p.PrioridadTarea);
            tarea.Ignore(p=>p.Resumen);
            tarea.HasData(tareasInit);

        });
    }
}