using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectProductClient.Models;

public class Product
{
    //[Key]//! Así se declara con data annotations. En TareasContext esta especificado con FLUENT API
    public Guid ProductId { get; set; }

    //[ForeignKey("ClientId")]
    public Guid ClientId { get; set; }

    //[Required]
    public string NameProduct { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    //*public virtual ICollection<Client> Client {get; set;}
    public virtual Client Client { get; set; }
    
    
}