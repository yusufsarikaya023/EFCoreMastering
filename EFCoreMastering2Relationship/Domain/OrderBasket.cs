namespace EFCoreMastering2Relationship.Domain;

public class OrderBasket
{
    public string OrderNumber { get; set; }
    public Order Order { get; set; }
    
    public string Barcode { get; set; }
    public Book Book { get; set; }
    
    public int Quantity { get; set; }
}