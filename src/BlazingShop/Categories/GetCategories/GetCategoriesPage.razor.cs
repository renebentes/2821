using BlazingShop.Data;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Categories.GetCategories;

public partial class GetCategoriesPage
{
    private IEnumerable<GetCategoriesResponse> _categories = [];

    [Inject]
    public AppDbContext Context { get; set; } = default!;

    public async Task<GridDataProviderResult<GetCategoriesResponse>> CategoriesDataProvider(GridDataProviderRequest<GetCategoriesResponse> request)
    {
        _categories = await GetCategories();
        return await Task.FromResult(request.ApplyTo(_categories));
    }


    private async Task<IEnumerable<GetCategoriesResponse>> GetCategories()
        => await Context
            .Categories
            .AsNoTracking()
            .Select(c => new GetCategoriesResponse(c.Id, c.Title))
            .ToListAsync();
}
