﻿using BlazingShop.Data;

namespace BlazingShop.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseAppDbContextSeed(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        try
        {
            context.Seed();
        }
        catch (Exception)
        {
            throw;
        }

        return app;
    }
}
