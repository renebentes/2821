namespace BlazingShop.Models;

public class Product
{
    public Product(int id, string title, decimal price, int categoryId, Category category)
    {
        Id = id;
        Title = title;
        Price = price;
        CategoryId = categoryId;
        Category = category;
    }

    public Product()
    {

    }

    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; } = new();
}
