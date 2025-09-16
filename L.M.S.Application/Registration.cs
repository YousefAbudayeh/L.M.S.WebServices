using L.M.S.Application.Interfaces;
using L.M.S.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace L.M.S.Application;

public static class Registration
{
    public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBooksService, BooksService>();
        services.AddScoped<ICategoriesService, CategoriesService>();
    }
}