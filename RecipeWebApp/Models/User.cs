using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebApp.Models;


/// <summary>
/// Represents a user of the recipe web application.
/// </summary>
[Table("Users")]
public class User
{
    public int UserId {get; set;}

    [Column(TypeName = "varchar(40)")]
    [Required]
    public string UserName {get; set;} = null!;

    public DateOnly DayRegistered {get; set;} = DateOnly.FromDateTime(DateTime.Now);

    public IList<Recipe>? Recipes {get; set;} = new List<Recipe>();
}