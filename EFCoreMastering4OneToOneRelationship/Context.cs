using EFCoreMastering4OneToOneRelationship.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastering4OneToOneRelationship;

public class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }
    
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<BrandImage> BrandImages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BrandImage>()
            .HasOne(x => x.Brand)
            .WithOne(x => x.Image)
            .HasForeignKey<BrandImage>(x => x.BrandId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}