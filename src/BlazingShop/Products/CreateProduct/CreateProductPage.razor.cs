using BlazingShop.Products.Common;

namespace BlazingShop.Products.CreateProduct;

public partial class CreateProductPage
{
    private readonly CreateProductInput _model = new();

    private readonly IEnumerable<GetCategoriesQuery> _categories = [];

    async Task HandleSubmitAsync() { }
}
