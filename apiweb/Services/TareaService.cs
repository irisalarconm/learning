using apiweb.Models;

namespace apiweb.Services;

public class TareaService : ITareaService
{
    TareasContext context;

     public TareaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }  

    public async Task Save(Tarea tarea) //void 
    {
        context.Add(tarea);
        //context.SaveChanges(); //se usa si el metodo es void y no async
        await context.SaveChangesAsync();
    }

     public async Task Update(Guid id, Tarea tarea) //void 
    {
        var TareaActual = context.Tareas.Find(id);

        if(TareaActual != null)
        {
            TareaActual.Titulo = tarea.Titulo;
            TareaActual.CategoriaId = tarea.CategoriaId;
            TareaActual.Descripcion = tarea.Descripcion;
            TareaActual.PrioridadTarea = tarea.PrioridadTarea;
            TareaActual.FechaCreacion = tarea.FechaCreacion;
            
            await context.SaveChangesAsync();

        }     
    }

    public async Task Delete(Guid id) //void 
    {
        var TareaActual = context.Tareas.Find(id);

        if(TareaActual != null)
        {
            context.Remove(TareaActual);
            await context.SaveChangesAsync();
        }     
    }


}

public interface ITareaService
{
    IEnumerable<Tarea> Get();

    Task Save(Tarea tarea);

    Task Update(Guid id, Tarea tarea);

    Task Delete(Guid id);
}