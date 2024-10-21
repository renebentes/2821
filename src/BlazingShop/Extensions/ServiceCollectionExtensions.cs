namespace BlazingShop.Extensions;

public static class ServiceCollectionExtensions
{
    private const string DefaultConnection = nameof(DefaultConnection);

    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<AppDbContext>(options
            => options.UseSqlite(configuration.GetConnectionString(DefaultConnection))
        );

        return services;
    }
}
