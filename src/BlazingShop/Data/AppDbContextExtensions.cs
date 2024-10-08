using BlazingShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Data;

public static class AppDbContextExtensions
{
    public static AppDbContext ApplyMigration(this AppDbContext context)
    {
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        return context;
    }

    public static void Seed(this AppDbContext context)
    {
        if (!context.Categories.Any())
        {
            context.Categories.Add(new Category(1, "Sem Categoria"));
            context.SaveChanges();
        }
    }
}
