
namespace BlazingShop.Categories.CreateCategory;

public partial class CreateCategoryPage : ComponentBase
{
    private string _errorMessage = string.Empty;

    [Inject]
    public AppDbContext Context { get; set; } = null!;

    [SupplyParameterFromForm]
    protected CreateCategoryInput Model { get; set; } = new();

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    async Task OnValidateSubmitAsync()
    {
        try
        {
            var category = new Category(
                Model.Title
            );

            await Context.Categories.AddAsync(category);
            await Context.SaveChangesAsync();
            NavigationManager.NavigateTo("/categories");
        }
        catch (Exception ex)
        {
            _errorMessage = ex.Message;
            throw;
        }
    }
}
