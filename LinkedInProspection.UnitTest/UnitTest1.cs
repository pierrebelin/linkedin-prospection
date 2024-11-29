using System.Text.Json;
using FluentAssertions;
using LinkedInProspection.WebAPI.Infrastructure.LinkedInScraper;

namespace LinkedInProspection.UnitTest;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        var webApplicationFactory = new DebugWebApplicationFactory();
        var client = webApplicationFactory.CreateClient();
        var response = await client.GetAsync("/icebreakers?username=pierre-belin&postedAfter=26-10-2024");
        response.EnsureSuccessStatusCode();
    }
}