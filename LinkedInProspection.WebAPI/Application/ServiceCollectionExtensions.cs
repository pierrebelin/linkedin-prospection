using LinkedInProspection.WebAPI.Application.GenerateIceBreakers;

namespace LinkedInProspection.WebAPI.Application;

public static class ServiceCollectionExtensions 
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<RetrieverService>();
        services.AddScoped<IGenerateIceBreakerQueryHandler, GenerateIceBreakerQueryHandler>();
        return services;
    }
}