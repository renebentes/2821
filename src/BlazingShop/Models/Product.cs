﻿namespace BlazingShop.Models;

public class Product
{

    public Product()
    {

    }

    public Product(int id, string title, string description, string image, decimal price, Category category)
    {
        Id = id;
        Title = title;
        Description = description;
        Image = image;
        Price = price;
        Category = category;
        CategoryId = category.Id;
    }

    public Category Category { get; set; } = new();

    public int CategoryId { get; set; }

    public string Description { get; set; } = string.Empty;

    public int Id { get; set; }

    public string Image { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Title { get; set; } = string.Empty;
}