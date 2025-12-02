using System.ComponentModel.DataAnnotations;

namespace RecipeWebApp.Models;

/// <summary>
/// Represents a recipe category.
/// </summary>

public class RecipeCategory
{   
    [Key]
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public IList<Recipe>? Recipes { get; set; } = new List<Recipe>();
}