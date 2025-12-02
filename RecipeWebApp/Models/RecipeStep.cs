using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebApp.Models;


/// <summary>
/// Represents a step in a recipe.
/// </summary>
[Table("RecipeSteps")]
public class RecipeStep
{   
    [Key]
    public int StepId {get; set;}

    [Required]
    public short StepOrder {get; set;}

    public string? Description {get; set;}

    public int RecipeId {get; set;}

    // Navigation property to the associated Recipe
    public Recipe Recipe {get; set;} = null!;
    
}