using System.Text.Json;
using FluentAssertions;
using LinkedInProspection.WebAPI.Infrastructure.LinkedInScraper;

namespace LinkedInProspection.UnitTest;

public class LinkedInScraperMapperTests
{
    [Fact]
    public void ShouldParseComments()
    {
        var response = File.ReadAllText("Files/ScrapedComments.json");
        var comments = JsonSerializer.Deserialize<ScrapedComment>(response);
        var commentsParsed = LinkedInScraperMapper.Map(comments);
        commentsParsed.Should().HaveCount(47);
    }
    
    [Fact]
    public void ShouldParsePosts()
    {
        var response = File.ReadAllText("Files/ScrapedPosts.json");
        var posts = JsonSerializer.Deserialize<ScrapedPost>(response);
        var postsParsed = LinkedInScraperMapper.Map(posts);
        postsParsed.Should().HaveCount(2);
    }
}