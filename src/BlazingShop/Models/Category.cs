namespace BlazingShop.Models;

public class Category
{
    public Category(int id, string title)
    {
        Id = id;
        Title = title;
    }

    private Category()
    {
    }

    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
}
