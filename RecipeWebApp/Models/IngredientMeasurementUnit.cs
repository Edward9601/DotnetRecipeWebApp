using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebApp.Models;

/// <summary>
/// Represents a measurement unit for ingredients.
/// </summary>
public class IngredientMeasurementUnit
{
    [Key]
    public int MeasurementUnitId { get; set; }

    [Column(TypeName = "varchar(15)")]
    public string Name { get; set; } = null!;

    [Column(TypeName = "varchar(5)")]
    public string Abbreviation { get; set; } = null!;
}