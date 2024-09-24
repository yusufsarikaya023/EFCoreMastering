using System.Text.Json.Serialization;
using EFCoreMastering4OneToOneRelationship;
using EFCoreMastering4OneToOneRelationship.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// System.Text.Json.JsonException: A possible object cycle was detected. Fix 

builder.Services
    .Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


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

app.MapPost("/insert", async (Context context, BrandDto dto) =>
    {
        var brand = new Brand
        {
            BrandName = dto.BrandName,
            Image = new BrandImage
            {
                ImageUrl = dto.ImageUrl
            }
        };

        await context.Brands.AddAsync(brand);
        await context.SaveChangesAsync();
        return Results.Ok();
    }).WithName("InsertBrand")
    .WithOpenApi();


app.MapPost("/updateTracking", async (Context context, BrandUpdateDto dto) =>
    {
        var brand = await context.Brands
            .Include(x => x.Image)
            .FirstOrDefaultAsync(x => x.Id == dto.id);
        
        if (brand is null) return Results.NotFound();
        
        brand.BrandName = dto.BrandName;
        brand.Image.ImageUrl = dto.ImageUrl;

        await context.SaveChangesAsync();
        return Results.Ok();
    }).WithName("UpdateBrandTracking")
    .WithOpenApi();

app.MapPost("/updateNoTracking", async (Context context, BrandUpdateDto dto) =>
    {
        var brand = await context.Brands
            .Include(x => x.Image)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == dto.id);
        
        if (brand is null) return Results.NotFound();
        
        brand.BrandName = dto.BrandName;
        brand.Image.ImageUrl = dto.ImageUrl;
        
        context.Update(brand);
        await context.SaveChangesAsync();
        return Results.Ok();
    }).WithName("updateBrandNoTracking")
    .WithOpenApi();

app.MapDelete("/delete", async (Context context, int id) =>
    {
        var brand = await context.Brands
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if (brand is null) return Results.NotFound();
        
        context.Brands.Remove(brand);
        await context.SaveChangesAsync();
        return Results.Ok();
    }).WithName("DeleteBrand")
    .WithOpenApi();

app.MapGet("/get", async (Context context) =>
    {
        var brands = await context.Brands
            .Include(x => x.Image)
            .ToListAsync();
        
        return Results.Ok(brands);
    }).WithName("GetBrands")
    .WithOpenApi();


app.Run();

record BrandDto(string BrandName, string ImageUrl);
record BrandUpdateDto(int id, string BrandName, string ImageUrl);
