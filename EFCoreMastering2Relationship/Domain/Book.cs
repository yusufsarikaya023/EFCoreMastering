namespace EFCoreMastering2Relationship.Domain;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    
    public Category MainCategory { get; set; } = null!;

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    
    public int? SectionId { get; set; }
    public Section? Section { get; set; }
}