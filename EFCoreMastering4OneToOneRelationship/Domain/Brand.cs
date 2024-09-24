namespace EFCoreMastering4OneToOneRelationship.Domain;

public class Brand
{
    public int Id { get; set; }
    
    public string BrandName { get; set; } = null!;
    
    public BrandImage Image { get; set; } = null!;
}