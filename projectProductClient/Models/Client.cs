using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace projectProductClient.Models;

public class Client
{
    //[Key]//! Así se declara con data annotations. En TareasContext esta especificado con FLUENT API
    public Guid ClientId { get; set; }

    //[Required]
    //[MaxLength(150)]
    public string NameClient { get; set; }
    public string LastnameClient { get; set; }

    public int DNIClient {get;set;}
    public string AdressClient { get; set; }
    
    //[Phone]
    public int Phone { get; set; }
    public Status status { get; set; }

    //*public virtual Product Product { get; set; }

    [JsonIgnore]
    public virtual ICollection<Product> Product {get; set;}

}

public enum Status
{
    Activo, 

    Inactivo,

    Bloqueado
}