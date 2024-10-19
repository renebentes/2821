using BlazingShop.Data;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Products.GetProducts;

public partial class GetProductsPage
{
    private IEnumerable<GetProductsResponse> _products = [];

    [Inject]
    public AppDbContext Context { get; set; } = default!;

    public async Task<GridDataProviderResult<GetProductsResponse>> ProductsDataProvider(GridDataProviderRequest<GetProductsResponse> request)
    {
        _products = await GetProductsAsync();
        return await Task.FromResult(request.ApplyTo(_products));
    }

    protected override async Task OnInitializedAsync()
        => _products = await GetProductsAsync();

    private async Task<IEnumerable<GetProductsResponse>> GetProductsAsync()
        => await Context
            .Products
            .Include(product => product.Category)
            .AsNoTracking()
            .Select(p => (GetProductsResponse)p)
            .ToListAsync();
}
