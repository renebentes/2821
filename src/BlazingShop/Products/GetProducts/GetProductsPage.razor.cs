using BlazorBootstrap;

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

    private async Task<IEnumerable<GetProductsResponse>> GetProductsAsync()
        => await Context
            .Products
            .Include(product => product.Category)
            .AsNoTracking()
            .Select(p => (GetProductsResponse)p)
            .ToListAsync();
}
