using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RecipeWebApp.Models;

/// <summary>
/// Represents a recipe created by a user.
/// </summary>
[Table("Recipes")]
public class Recipe
{
    public int RecipeId {get; set;}

    public int AuthorId {get; set;}

    [Required]
    public User Author {get; set;} = null!;

    [Column(TypeName = "varchar(70)")]
    [Required]
    public string Title {get; set;} = null!;
    public string? Description {get; set;}

    public DateOnly DateCreated {get; set;} = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly? LastUpdated {get; set;}
    public bool IsSubRecipe {get; set;} = false;

    public IList<RecipeSubrecipe>? Subrecipes { get; set; } = new List<RecipeSubrecipe>();
    public IList<RecipeSubrecipe>? ParentRecipes { get; set; } = new List<RecipeSubrecipe>();

    // Navigation property for recipe ingredients
    public IList<Ingredient>? Ingredients {get; set;} = new List<Ingredient>();

    // Navigation property for recipe steps
    public IList<RecipeStep>? Steps {get; set;} = new List<RecipeStep>();

    // Navigation property for recipe tags
    public IList<RecipeTag>? RecipeTags {get; set;} = new List<RecipeTag>();

    // Navigation property for recipe categories
    public IList<RecipeCategory>? RecipeCategories {get; set;} = new List<RecipeCategory>();
}

/// <summary>
/// Represents the many-to-many relationship between recipes and their subrecipes.
/// </summary>
public class RecipeSubrecipe
{
    public int ParentRecipeId { get; set; }
    public Recipe ParentRecipe { get; set; } = null!;
    public int SubrecipeId { get; set; }

    public Recipe Subrecipe { get; set; } = null!;
}