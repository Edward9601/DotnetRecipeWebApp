using Microsoft.EntityFrameworkCore;
using RecipeWebApp.Data;
using RecipeWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RecipeDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    .UseSeeding((context, _) =>
    {
        if (!context.Set<IngredientMeasurementUnit>().Any())
        {
            Dictionary<string, string> units = new()
            {
                    {"Cup", "cup"},
                    {"Tablespoon", "tbsp"},
                    {"Teaspoon", "tsp"},
                    {"Gram", "gram"},
                    {"Kilogram", "kg"},
                    {"Ounce", "oz"},
                    {"Pound", "lb"},
                    {"Milliliter", "ml"},
                    {"Liter", "liter"},
                    {"Piece", "piece"},
                    {"Slice", "slice"},
                    {"Bag", "bag"},
                    {"Can", "can"},
                    {"Clove", "clove"}
                };
                for (int i = 0; i < units.Count; i++)
                {
                    var unit = units.ElementAt(i);
                    context.Set<IngredientMeasurementUnit>().Add(new IngredientMeasurementUnit
                    {
                        MeasurementUnitId = i + 1,
                        Name = unit.Key,
                        Abbreviation = unit.Value
                    });
                }
        }
        if (!context.Set<RecipeTag>().Any())
        {
            string[] tagNames =
            [
                "Vegan",
                "Gluten-free",
                "Low-carb",
                "Fancy",
                "Salty",
                "Energy",
                "Chocolate",
                "Fruit-based",
                "Cold",
                "Warm",
                "Quick",
                "Healthy",
                "Light",
                "Sweet",
                "Savory",
            ];
            for (int i = 0; i < tagNames.Length; i++)
            {
                context.Set<RecipeTag>().Add(new RecipeTag
                {
                    Name = tagNames[i]
                });
            }
        }
        if(!context.Set<RecipeCategory>().Any())
        {
            string[] categoryNames =
            [
                "Breakfast",
                "Lunch or Dinner",
                "Snack",
                "Dessert"
            ];
            for (int i = 0; i < categoryNames.Length; i++)
            {
                context.Set<RecipeCategory>().Add(new RecipeCategory
                {
                    Name = categoryNames[i]
                });
            }
        }
        if(context.ChangeTracker.HasChanges())
        {
            context.SaveChanges();
        }
    })
    .UseAsyncSeeding(async (context, _, cancellationToken) =>
    {
        if (!context.Set<IngredientMeasurementUnit>().Any())
        {
            Dictionary<string, string> units = new()
            {
                    {"Cup", "cup"},
                    {"Tablespoon", "tbsp"},
                    {"Teaspoon", "tsp"},
                    {"Gram", "gram"},
                    {"Kilogram", "kg"},
                    {"Ounce", "oz"},
                    {"Pound", "lb"},
                    {"Milliliter", "ml"},
                    {"Liter", "liter"},
                    {"Piece", "piece"},
                    {"Slice", "slice"},
                    {"Bag", "bag"},
                    {"Can", "can"},
                    {"Clove", "clove"}
                };
                for (int i = 0; i < units.Count; i++)
                {
                    var unit = units.ElementAt(i);
                    context.Set<IngredientMeasurementUnit>().Add(new IngredientMeasurementUnit
                    {
                        Name = unit.Key,
                        Abbreviation = unit.Value
                    });
                }
        }
        if (!context.Set<RecipeTag>().Any())
        {
            string[] tagNames =
            [
                "Vegan",
                "Gluten-free",
                "Low-carb",
                "Fancy",
                "Salty",
                "Energy",
                "Chocolate",
                "Fruit-based",
                "Cold",
                "Warm",
                "Quick",
                "Healthy",
                "Light",
                "Sweet",
                "Savory",
            ];
            for (int i = 0; i < tagNames.Length; i++)
            {
                context.Set<RecipeTag>().Add(new RecipeTag
                {
                    Name = tagNames[i]
                });
            }
        }
        if(!context.Set<RecipeCategory>().Any())
        {
            string[] categoryNames =
            [
                "Breakfast",
                "Lunch or Dinner",
                "Snack",
                "Dessert"
            ];
            for (int i = 0; i < categoryNames.Length; i++)
            {
                context.Set<RecipeCategory>().Add(new RecipeCategory
                {
                    Name = categoryNames[i]
                });
            }
        }
        if(context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RecipeDbContext>();
    dbContext.Database.EnsureCreated();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
