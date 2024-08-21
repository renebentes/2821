using BlazingShop.Data;
using BlazingShop.Models;
using BlazingShop.Products.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Products.CreateProduct;

public partial class CreateProductPage
{
    private readonly CreateProductInput _model = new();
    private string _errorMessage = string.Empty;

    private IEnumerable<GetCategoriesQuery> _categories = [];

    [Inject]
    public AppDbContext Context { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        _categories = await Context.Categories.AsNoTracking()
                                              .Select(c => new GetCategoriesQuery(c.Id, c.Title))
                                              .ToListAsync();
    }

    public async Task HandleSubmitAsync()
    {
        try
        {
            var category = await Context.Categories.FindAsync(_model.CategoryId);

            if (category is null)
            {
                _errorMessage = $"Categoria com identificador {_model.CategoryId} não encontrada";
                return;
            }

            var product = new Product(_model.Title, _model.Description, _model.Image, _model.Price, category);
            await Context.Products.AddAsync(product);
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
            throw;
        }
    }
}
