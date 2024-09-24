namespace EFCoreMastering4OneToOneRelationship.Domain;

public class BrandImage
{
    public int Id { get; set; }
    
    public Brand Brand { get; set; } = null!;
    public int BrandId { get; set; }
    
    public string ImageUrl { get; set; } = null!;
}