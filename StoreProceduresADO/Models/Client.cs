using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StoreProceduresADO.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        public string NameClient { get; set; }
        public string LastnameClient { get; set; }
        public long DNIClient { get; set; }
        public string AdressClient { get; set; }      
        public long Phone { get; set; }
        public Status status { get; set; }

        //*public virtual Product Product { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Product { get; set; }

    }
    public enum Status
    {
        Activo,

        Inactivo,

        Bloqueado
    }
}
