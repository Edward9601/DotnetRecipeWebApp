namespace RecipeWebApp.Models;
using RecipeWebApp.Models.Abstracts;

public class RecipeImage : BaseImage
{
    public int RecipeId {get; set;}
    public Recipe Recipe {get; set;} = null!;
}