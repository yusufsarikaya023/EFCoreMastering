namespace EFCoreMastering2Relationship.Domain;

public class Section
{
    public int Id { get; set; }
    public string SectionName { get; set; } = string.Empty;
    public int RowNumber { get; set; }
    
    public ICollection<Book> Books { get; set; } = new HashSet<Book>();
}