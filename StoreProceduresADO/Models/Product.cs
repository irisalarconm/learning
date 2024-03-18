using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProceduresADO.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //*public virtual ICollection<Client> Client {get; set;}
        public virtual Client Client { get; set; }
    }
}
