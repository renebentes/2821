using BlazingShop.Data;
using BlazingShop.Models;
using BlazingShop.Products.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Products.CreateProduct;

public partial class CreateProductPage : ComponentBase
{
    private IEnumerable<GetCategoriesQuery> _categories = [];

    private string _errorMessage = string.Empty;

    [Inject]
    public AppDbContext Context { get; set; } = null!;

    [SupplyParameterFromForm]
    public CreateProductInput Model { get; set; } = new();

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    public async Task HandleSubmitAsync()
    {
        try
        {
            var category = await Context.Categories.FindAsync(Model.CategoryId);

            if (category is null)
            {

                _errorMessage = $"Categoria com identificador {Model.CategoryId} não encontrada";
                return;
            }

            var product = new Product(Model.Title, Model.Description, Model.Image, Model.Price, category);
            await Context.Products.AddAsync(product);
            await Context.SaveChangesAsync();
            NavigationManager.NavigateTo("/products");
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
            throw;
        }
    }

    protected override async Task OnInitializedAsync()
    => _categories = await Context.Categories.AsNoTracking()
        .Select(c => new GetCategoriesQuery(c.Id, c.Title))
        .ToListAsync();
}
