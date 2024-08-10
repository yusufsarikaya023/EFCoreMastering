namespace EFCoreMastering2Relationship.Domain;

public class OrderComment
{ 
    public int Id { get; set; }
    
    public string OrderNumber { get; set; } // Foreign Key
    public string Barcode { get; set; } // Foreign Key
    
    public OrderBasket OrderBasket { get; set; } = null!; // Navigation Property

    public string Name { get; set; }
    public string Comment { get; set; }
    public DateTime CommentDate { get; set; }
}