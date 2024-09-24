using EFCoreMastering3SelfReferencing.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastering3SelfReferencing;

public class Context: DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    
    public Context()
    {
    }
    
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasOne(x => x.ParentCategory)
            .WithMany(x => x.SubCategories)
            .HasForeignKey(x => x.ParentCategoryId)
            .IsRequired(false);
        
        base.OnModelCreating(modelBuilder);
    }
}