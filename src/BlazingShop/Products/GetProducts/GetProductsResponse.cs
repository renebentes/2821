namespace BlazingShop.Products.GetProducts;

public sealed record GetProductsResponse(int Id, string Title, string Image, decimal Price, string Category)
{
    public static implicit operator GetProductsResponse(Product product)
        => new(product.Id,
               product.Title,
               product.Image,
               product.Price,
               product.Category.Title);
}
