namespace EFCoreMastering3SelfReferencing.Domain;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!; // Category name, required field

    public int? ParentCategoryId { get; set; } // Foreign key to parent category
    public Category? ParentCategory { get; set; } // Navigation property to parent category

    public ICollection<Category> SubCategories { get; set; } = new HashSet<Category>(); // Navigation property to child categories
}
    