using L.M.S.Application.Persistence;

namespace L.M.S.Application.WebApi.Extensions;

internal static class StartupExtensions
{
    public const string AnyOriginPolicyName = "AllowAllPolicy";

    public static void SetupServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAppServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);
    }

    public static void SetupCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(AnyOriginPolicyName, builder =>
            {
                builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(_ => true);
            });
        });
    }
}