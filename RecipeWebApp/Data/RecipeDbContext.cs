namespace RecipeWebApp.Data;
using Microsoft.EntityFrameworkCore;
using RecipeWebApp.Enums;
using RecipeWebApp.Models;
using RecipeWebApp.Models.Abstracts;

public class RecipeDbContext : DbContext
{
    public RecipeDbContext(DbContextOptions<RecipeDbContext> options): base(options)
    {   
    }
    public DbSet<Recipe> Recipes {get; set;} = null!;
    public DbSet<RecipeCategory> RecipeCategories {get; set;} = null!;
    public DbSet<RecipeTag> RecipeTags {get; set;} = null!;
    public DbSet<RecipeStep> RecipeSteps {get; set;} = null!;
    public DbSet<Ingredient> Ingredients {get; set;} = null!;
    public DbSet<User> Users {get; set;} = null!;
    public DbSet<BaseImage> BaseImages {get; set;} = null!;
    public DbSet<IngredientMeasurementUnit> IngredientMeasurementUnits {get; set;} = null!;




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BaseImage>()
        .ToTable("Images")
        .HasDiscriminator<ImageType>("ImageType")
        .HasValue<UserImage>(ImageType.UserImage)
        .HasValue<RecipeImage>(ImageType.RecipeImage);

        modelBuilder.Entity<RecipeSubrecipe>(entity =>
        {
            // Configure composite primary key
            entity.HasKey(rs => new { rs.ParentRecipeId, rs.SubrecipeId });
            
            // Configure relationships
            entity.HasOne(rs => rs.ParentRecipe)
            .WithMany(r => r.Subrecipes)
            .HasForeignKey(rs => rs.ParentRecipeId)
            .OnDelete(DeleteBehavior.Restrict);
            
            // Configure relationships
            entity.HasOne(rs => rs.Subrecipe)
            .WithMany(r => r.ParentRecipes)
            .HasForeignKey(rs => rs.SubrecipeId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.ToTable(t => t.HasCheckConstraint(
                "CK_RecipeSubrecipes_NoSelfReference",
                "\"ParentRecipeId\" <> \"SubrecipeId\""
            ));
        });
    }
}

