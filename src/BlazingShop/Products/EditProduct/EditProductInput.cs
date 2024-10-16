using BlazingShop.Models;
using BlazingShop.Products.CreateProduct;
using System.ComponentModel.DataAnnotations;

namespace BlazingShop.Products.EditProduct;

public sealed record EditProductInput : CreateProductInput
{
    [Required(ErrorMessage = "Id é obrigatório")]
    public int Id { get; set; }

    public static implicit operator EditProductInput(Product product)
        => new()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Image = product.Image,
            Price = product.Price,
            CategoryId = product.Category.Id
        };
}
