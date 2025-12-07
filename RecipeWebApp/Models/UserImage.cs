namespace RecipeWebApp.Models;
using RecipeWebApp.Models.Abstracts;

public class UserImage : BaseImage
{
    public int UserId {get; set;}
    public User User {get; set;} = null!;
}