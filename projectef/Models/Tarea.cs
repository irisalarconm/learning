using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectef.Models;

public class Tarea
{
    //[Key] //! Así se declara con data annotations. En TareasContext esta especificado con FLUENT API
    public Guid TareaId {get;set;}

    //[ForeignKey("CategoriaId")]
    public Guid CategoriaId {get;set;}

    //[Required]
    //[MaxLength(200)]
    public string Titulo {get;set;}

    public string Descripcion {get;set;}

    public Prioridad PrioridadTarea {get;set;}

    public DateTime FechaCreacion {get;set;}

    public virtual Categoria Categoria {get;set;}

    //[NotMapped] //ESTE ATRIBUTO HACE QUE OMITA EL CAMPO EN EL MOMENTO DE LA CREACIÓN DE LA BASE DE DATOS => No lo crea
    public string Resumen {get; set;}

}

public enum Prioridad
{
    Baja,
    Media,
    Alta,
}