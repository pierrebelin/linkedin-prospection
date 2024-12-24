using LinkedInProspection.UnitTest.Mocks;
using LinkedInProspection.WebAPI.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace LinkedInProspection.UnitTest;

public class DebugWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddScoped<ILinkedInScraperService, MockLinkedInScraperService>();
            services.AddScoped<ILLMService, MockClaudeLLMService>();
        });
    }}