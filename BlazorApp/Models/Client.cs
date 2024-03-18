using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string NameClient { get; set; }
        public string LastnameClient { get; set; }
        public long DNIClient { get; set; }
        public string AdressClient { get; set; }
        public long Phone { get; set; }
        public string status { get; set; }
    }
}
