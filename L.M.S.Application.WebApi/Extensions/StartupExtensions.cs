using L.M.S.Application.Persistence;

namespace L.M.S.Application.WebApi.Extensions;

internal static class StartupExtensions
{
    public static void SetupServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAppServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);
    }
}