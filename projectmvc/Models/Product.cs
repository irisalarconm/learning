
public class Product
{
    public int ProductId { get; set; }

    public int ClientId { get; set; }
    public string NameProduct { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public virtual Client Client { get; set; }
}