using BlazingShop.Models;

namespace BlazingShop.Data;

public static class AppDbContextSeed
{
    public static void Seed(this AppDbContext context)
    {
        if (!context.Categories.Any())
        {
            context.Categories.Add(new Category(1, "Sem Categoria"));
            context.SaveChanges();
        }
    }
}
