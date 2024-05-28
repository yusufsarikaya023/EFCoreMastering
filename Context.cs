using EFCoreMastering.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMastering;

public class Context: DbContext
{
    public Context(){}

    public Context(DbContextOptions<Context> options) : base(options){}
    
    public DbSet<Book> Books { get; set; } = null!;
}