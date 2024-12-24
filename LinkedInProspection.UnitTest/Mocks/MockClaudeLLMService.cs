using System.Text.Json;
using LinkedInProspection.WebAPI.Application.Interfaces;
using LinkedInProspection.WebAPI.Domain;

namespace LinkedInProspection.UnitTest.Mocks;

public class MockClaudeLLMService : ILLMService
{
    public async Task<ContentIceBreaker[]> GetIceBreakers(ProspectInformation prospectInformation)
    {
        var response = await File.ReadAllTextAsync("Mocks/Files/ContentIceBreakers.json");
        var iceBreakers = JsonSerializer.Deserialize<ContentIceBreaker[]>(response)!;
        return iceBreakers;
    }
}
