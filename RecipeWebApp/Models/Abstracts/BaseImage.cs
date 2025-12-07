namespace RecipeWebApp.Models.Abstracts;

public abstract class BaseImage
{
    public int Id {get; set;}
    public string OriginalImageName {get; set;} = null!;

    public string MidiumImageName {get; set;} = null!;

    public string SmallImageName {get; set;} = null!;

}