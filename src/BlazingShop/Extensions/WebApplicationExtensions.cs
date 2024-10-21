namespace BlazingShop.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseAppDbContext(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        try
        {
            context.ApplyMigration()
                .Seed();
        }
        catch (Exception)
        {
            throw;
        }

        return app;
    }
}
