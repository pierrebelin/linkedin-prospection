using System.Text.Json;
using LinkedInProspection.WebAPI.Application.Interfaces;
using LinkedInProspection.WebAPI.Domain;

namespace LinkedInProspection.UnitTest.Mocks;

public class MockLinkedInScraperService : ILinkedInScraperService
{
    public async Task<Post[]> ScrapePosts(Username username, DateTime? postedAfter = null)
    {
        var response = await File.ReadAllTextAsync("Mocks/Files/Posts.json");
        var posts = JsonSerializer.Deserialize<Post[]>(response)!;
        return posts;
    }

    public async Task<Comment[]> ScrapeComments(Username username, DateTime? postedAfter = null)
    {
        var response = await File.ReadAllTextAsync("Mocks/Files/Comments.json");
        var comments = JsonSerializer.Deserialize<Comment[]>(response)!;
        return comments;
    }
}
