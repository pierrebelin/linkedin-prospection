using System.Net;
using FluentAssertions;

namespace LinkedInProspection.UnitTest;

public class ContractTests
{
    [Fact]
    public async Task Start()
    {
        var webApplicationFactory = new DebugWebApplicationFactory();
        var client = webApplicationFactory.CreateClient();
        var response = await client.GetAsync("/icebreakers?username=pierre-belin&postedAfter=10-12-2024");
        var message = await response.Content.ReadAsStringAsync();
        response.StatusCode.Should().Be(HttpStatusCode.OK, message);
    }
}