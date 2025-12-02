using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebApp.Models;


/// <summary>
/// Represents an ingredient used in a recipe.
/// </summary>
[Table("Ingredients")]
public class Ingredient
{
    public int IngredientId {get; set;}

    [Column(TypeName = "varchar(70)")]
    [Required]
    public string Name {get; set;} = null!;

    /// Quantity as a string to accommodate fractions and various formats
    [Column(TypeName = "varchar(10)")]
    public string? Quantity {get; set;}

    public IngredientMeasurementUnit? IngredientMeasurementUnit {get; set;}

    public int RecipeId {get; set;}
    
    // Navigation property to the associated Recipe
    public Recipe Recipe {get; set;} = null!;
}