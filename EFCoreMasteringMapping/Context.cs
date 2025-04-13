using EFCoreMasteringMapping.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMasteringMapping;

public class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(prop => prop.Email)
                .IsUnicode(false)
                .HasMaxLength(256);

            entity.Property(prop => prop.Name)
                .HasMaxLength(256);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(prop => prop.Category)
                .HasColumnType("varchar(30)")
                .HasConversion(
                    v => v.ToString(),
                    v => (BookCategory)Enum.Parse(typeof(BookCategory), v)
                );
        });

        base.OnModelCreating(modelBuilder);
    }
}