using System;
using System.Collections.Generic;

namespace projecPrueba.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string NameProduct { get; set; } = null!;

    public string? DescriptionProduct { get; set; }

    public decimal PriceProduct { get; set; }

    public int ClientId { get; set; }

    public virtual Client Client { get; set; } = null!;
}
