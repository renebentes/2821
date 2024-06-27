using BlazingShop.Data;
using BlazingShop.Products.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Products.CreateProduct;

public partial class CreateProductPage
{

    private readonly CreateProductInput _model = new();

    private IEnumerable<GetCategoriesQuery> _categories = [];

    [Inject]
    public AppDbContext Context { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        _categories = await Context.Categories.AsNoTracking()
                                              .Select(c => new GetCategoriesQuery(c.Id, c.Title))
                                              .ToListAsync();
    }

    async Task HandleSubmitAsync() { }
}
