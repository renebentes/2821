using BlazingShop.Categories.GetCategories;
using BlazingShop.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Products.EditProduct;

public partial class EditProductPage : ComponentBase
{
    private IEnumerable<GetCategoriesResponse> _categories = [];
    private string _errorMessage = string.Empty;

    [Inject]
    public AppDbContext Context { get; set; } = null!;

    [Parameter]
    public int Id { get; set; }

    [SupplyParameterFromForm]
    public EditProductInput Model { get; set; } = new();

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    public async Task HandleSubmitAsync()
    {
        try
        {
            var category = await Context
                .Categories
                .FindAsync(Model.CategoryId);

            if (category is null)
            {
                _errorMessage = $"Categoria com identificador {Model.CategoryId} não encontrada";
                return;
            }

            var product = await Context
                .Products
                .FindAsync(Model.Id);

            if (product is null)
            {
                _errorMessage = $"Produto com identificador {Model.Id} não encontrado";
                return;
            }

            product.Title = Model.Title;
            product.Category = category;
            product.Description = Model.Description;
            product.Image = Model.Image;
            product.Price = Model.Price;
            Context.Products.Update(product);
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
    {
        _categories = await Context
            .Categories
            .AsNoTracking()
            .Select(c => new GetCategoriesResponse(c.Id, c.Title))
            .ToListAsync();
    }
}
