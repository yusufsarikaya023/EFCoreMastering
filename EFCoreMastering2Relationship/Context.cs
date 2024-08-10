using EFCoreMastering2Relationship.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastering2Relationship;

public class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<Author>? Authors { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Book>? Books { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderBasket>? OrderBaskets { get; set; }
    
    public DbSet<OrderComment>? OrderComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany(x => x.Books)
            .WithOne(x => x.Author)
            .HasForeignKey(b => b.AuthorId)
            .HasPrincipalKey(x => x.Id)
            .IsRequired();

        modelBuilder.Entity<Section>()
            .HasMany(x => x.Books)
            .WithOne(x => x.Section)
            .HasForeignKey(b => b.SectionId)
            .HasPrincipalKey(x => x.Id)
            .IsRequired(false);

        modelBuilder.Entity<OrderBasket>()
            .HasKey(x => new { x.OrderNumber, x.Barcode });
           
        modelBuilder.Entity<OrderBasket>()
            .HasOne(x => x.Book)
            .WithMany()
            .HasForeignKey(x => x.Barcode)
            .HasPrincipalKey(x => x.Barcode)
            .IsRequired();
        
        modelBuilder.Entity<OrderBasket>()
            .HasOne(x => x.Order)
            .WithMany()
            .HasForeignKey(x => x.OrderNumber)
            .HasPrincipalKey(x => x.OrderNumber)
            .IsRequired();
        
        modelBuilder.Entity<OrderComment>()
            .HasOne(x=>x.OrderBasket)
            .WithMany()
            .HasForeignKey(x=>new{x.OrderNumber,x.Barcode})
            .HasPrincipalKey(x=>new{x.OrderNumber,x.Barcode})
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}