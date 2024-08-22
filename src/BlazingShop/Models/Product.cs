namespace BlazingShop.Models;

public class Product
{
    public Product(string title, string description, string image, decimal price, Category category)
    {
        Title = title;
        Description = description;
        Image = image;
        Price = price;
        Category = category;
    }

    private Product()
    {

    }

    public Category Category { get; set; } = null!;

    public string Description { get; set; } = string.Empty;

    public int Id { get; set; }

    public string Image { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Title { get; set; } = string.Empty;
}
