using System.ComponentModel.DataAnnotations;

namespace RecipeWebApp.Models;

/// <summary>
/// Represents a tag that can be associated with recipes.
/// </summary>
public class RecipeTag
{
    [Key]
    public int TagId { get; set; }

    public string Name { get; set; } = null!;

    public IList<Recipe>? Recipes { get; set; } = new List<Recipe>();
}