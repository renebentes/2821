namespace BlazingShop.Models;

public class Category
{
    public Category(string title)
        => Title = title;

    private Category()
    {
    }

    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
}
