using L.M.S.Application.Common.Settings;
using L.M.S.Application.Domain.Persistence;
using L.M.S.Application.Persistence.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace L.M.S.Application.Persistence;

public static class Registration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection("Persistence").Get<PersistenceSettings>();
        services.AddSingleton(settings);

        services.AddScoped<IBooksRepository, BooksRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<BooksAdoRepository>();

        services.AddDbContext<LMSSqlContext>(options => options.UseSqlServer(settings.DefaultConnection));
    }
}