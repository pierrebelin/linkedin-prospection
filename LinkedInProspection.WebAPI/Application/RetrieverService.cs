using LinkedInProspection.WebAPI.Application.Interfaces;
using LinkedInProspection.WebAPI.Domain;

namespace LinkedInProspection.WebAPI.Application;

// https://rapidapi.com/rockapis-rockapis-default/api/linkedin-api8/playground/apiendpoint_a3d02638-e248-4eeb-9751-2a84708570ba

public class RetrieverService(ILinkedInScraperService linkedInScraperService, ILLMService llmService)
{
    public async Task<IceBreaker[]> GenerateIceBreakers(Username username, DateTime postedAfter)
    {
        var posts = await linkedInScraperService.ScrapePosts(username, postedAfter);
        var comments = await linkedInScraperService.ScrapeComments(username, postedAfter);

        var prospectInformation = ProspectInformation.Restore(posts, comments);
        return await llmService.GetIceBreakers(prospectInformation);
    }
}
