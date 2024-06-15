using EFCoreMastering2Relationship;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapGet("/getAuthorWithBooks", (Context context) =>
    {
        var authorWithBooks = context.Authors
            .Include(x=>x.Books)
            .ToArray();
        return authorWithBooks;
    })
    .WithName("GetAuthorWithBooks")
    .WithOpenApi();


app.MapPost("/setSectionBook", (Context Context, BookSetSectionDto dto) =>
    {
        var book = Context.Books!.Find(dto.BookId);
        book!.SectionId = dto.SectionId;
        Context.SaveChanges();
        return book;
    })
    .WithName("SetSectionBook")
    .WithOpenApi();


app.Run();

public class BookSetSectionDto
{
    public int BookId { get; set; }
    public int SectionId { get; set; }
}