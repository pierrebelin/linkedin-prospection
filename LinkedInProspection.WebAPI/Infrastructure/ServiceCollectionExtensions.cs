using LinkedInProspection.WebAPI.Application.Interfaces;
using LinkedInProspection.WebAPI.Infrastructure.LinkedInScraper;
using LinkedInProspection.WebAPI.Infrastructure.LLM;

namespace LinkedInProspection.WebAPI.Infrastructure;

public static class ServiceCollectionExtensions 
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddHttpClient<ILinkedInScraperService, LinkedInScraperService>();
        services.AddHttpClient<ILLMService, ClaudeLLMService>();
        return services;
    }
}