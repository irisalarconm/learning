namespace projectef.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//modelos en singular
public class Categoria
{
    //[Key] //! Así se declara con data annotations. En TareasContext esta especificado con FLUENT API
    public Guid CategoriaId {get;set;}

    //[Required] //Dataannotations o atributos
    //[MaxLength(150)]
    public string Nombre {get;set;}

    public string Descripcion {get; set;}

    public int Peso {get;set;}

    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;}

}