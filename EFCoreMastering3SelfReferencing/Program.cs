using System.Text.Json.Serialization;
using EFCoreMastering3SelfReferencing;
using EFCoreMastering3SelfReferencing.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer()
    .ConfigureHttpJsonOptions(x => x.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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

app.MapGet("/getCategoriesWithJoin", (Context context) =>
    {
        var categories = context.Categories
            .Include(x => x.ParentCategory)
            .Include(x => x.SubCategories).ThenInclude(x=>x.SubCategories)
            .Where(x => x.ParentCategoryId == null).ToList();
        
        return categories;
    })
    .WithName("getCategoriesWithJoin")
    .WithOpenApi();

app.MapGet("/getCategories", (Context context) =>
    {
        var categories = context.Categories
            .Where(x => x.ParentCategoryId == null).ToList();
        foreach (var category in categories) LoadChildren(category);
        return categories;

        void LoadChildren(Category _category)
        {
            context.Entry(_category)
                .Collection(c => c.SubCategories)
                .Load();
            foreach (var category in _category.SubCategories) LoadChildren(category);
        }
    })
    .WithName("GetCategories")
    .WithOpenApi();

app.MapPost("/addCategory", (Context context, CategoryDto dto) =>
    {
        Category category = new();
        category.Name = dto.name;
        category.ParentCategoryId = dto.parentCategoryId;
        context.Categories.Add(category);
        context.SaveChanges();
    })
    .WithName("addCategory")
    .WithOpenApi();


app.Run();

public record CategoryDto(string name, int? parentCategoryId);