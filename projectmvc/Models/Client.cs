using System.Collections.Generic;

public class Client
{
    public int ClientId { get; set; }
    public string NameClient { get; set; }
    public string LastnameClient { get; set; }

    public int DniClient { get; set; }

    public string AddressClient { get; set; }

    public int Phone { get; set; }

    public Status Status { get; set; }

    [JsonIgnore]
    public virtual ICollection<Product> Product { get; set; }
}

public enum Status
{
    Activo,

    Inactivo,

    Bloqueado
}