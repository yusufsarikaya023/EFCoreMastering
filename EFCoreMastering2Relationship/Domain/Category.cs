namespace EFCoreMastering2Relationship.Domain;

public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    public ICollection<Book> Books { get; set; } = new HashSet<Book>();
}