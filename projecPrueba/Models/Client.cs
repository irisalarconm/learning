using System;
using System.Collections.Generic;

namespace projecPrueba.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string NameClient { get; set; } = null!;

    public long Dniclient { get; set; }

    public string LastName { get; set; } = null!;

    public long Phone { get; set; }

    public string? AddressClient { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
