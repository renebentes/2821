﻿namespace BlazingShop.Models;

public class Category
{
    public Category()
    {
    }

    public Category(int id, string title)
    {
        Id = id;
        Title = title;
    }
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public IEnumerable<Product> Products { get; set; } = [];
}