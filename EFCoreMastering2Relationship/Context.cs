using EFCoreMastering2Relationship.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastering2Relationship;

public class Context: DbContext
{
    public Context(){}

    public Context(DbContextOptions<Context> options) : base(options){}
    
    public DbSet<Author>? Authors { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Book>? Books { get; set; }
    public DbSet<Category>? Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Author>()
            .HasMany(x=>x.Books)
            .WithOne(x=>x.Author)
            .HasForeignKey(b => b.AuthorId)
            .HasPrincipalKey(x => x.Id)
            .IsRequired();
        
        modelBuilder.Entity<Section>()
            .HasMany(x=>x.Books)
            .WithOne(x=>x.Section)
            .HasForeignKey(b => b.SectionId)
            .HasPrincipalKey(x => x.Id)
            .IsRequired(false);
    
        
        base.OnModelCreating(modelBuilder);
    }
}