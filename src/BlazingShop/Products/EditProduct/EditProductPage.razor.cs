﻿using BlazingShop.Data;
using BlazingShop.Products.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Products.EditProduct;

public partial class EditProductPage : ComponentBase
{
    private IEnumerable<GetCategoriesQuery> _categories = [];
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
            var category = await Context.Categories.FindAsync(Model.CategoryId);

            if (category is null)
            {
                _errorMessage = $"Categoria com identificador {Model.CategoryId} não encontrada";
                return;
            }

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
        _categories = await Context.Categories
           .AsNoTracking()
           .Select(c => new GetCategoriesQuery(c.Id, c.Title))
           .ToListAsync();

        Model = await Context.Products
            .Include(p => p.Category)
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == Id) ?? new EditProductInput();
    }
}