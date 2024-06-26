using BlazingShop.Data;
using BlazingShop.Products.Common;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Products.CreateProduct;

public partial class CreateProductPage(AppDbContext context)
{
    private readonly CreateProductInput _model = new();

    private IEnumerable<GetCategoriesQuery> _categories = [];

    protected override async Task OnInitializedAsync()
    {
        _categories = await context.Categories.AsNoTracking()
                                              .Select(c => new GetCategoriesQuery(c.Id, c.Title))
                                              .ToListAsync();
    }

    async Task HandleSubmitAsync() { }
}
