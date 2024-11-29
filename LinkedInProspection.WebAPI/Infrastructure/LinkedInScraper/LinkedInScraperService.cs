using System.Globalization;
using LinkedInProspection.WebAPI.Application.Interfaces;
using LinkedInProspection.WebAPI.Domain;

namespace LinkedInProspection.WebAPI.Infrastructure.LinkedInScraper;

public class LinkedInScraperService : ILinkedInScraperService
{
    private readonly HttpClient _httpClient;
    
    public LinkedInScraperService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        var apiKey = configuration["RapidApi:ApiKey"] 
                  ?? throw new ArgumentNullException(nameof(configuration));
        
        _httpClient.BaseAddress = new Uri("https://linkedin-api8.p.rapidapi.com");
        _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
    }

    public async Task<Post[]> ScrapePosts(Username username, DateTime? postedAfter = null)
    {
        var date = ConvertDateFormat(postedAfter);
        var response = await _httpClient.GetAsync($"/get-profile-posts?username={username.Value}&postedAt={date}");
        response.EnsureSuccessStatusCode();
        
        var posts = await response.Content.ReadFromJsonAsync<ScrapedPost>();
        return LinkedInScraperMapper.Map(posts);
    }

    public async Task<Comment[]> ScrapeComments(Username username, DateTime? postedAfter = null)
    {
        var response = await _httpClient.GetAsync($"/get-profile-comments?username={username.Value}");
        response.EnsureSuccessStatusCode();
        
        var comments = await response.Content.ReadFromJsonAsync<ScrapedComment>();
        return LinkedInScraperMapper.Map(comments, postedAfter);
    }
    
    private static string? ConvertDateFormat(DateTime? date)
    {
        return date?.ToString("yyyy-MM-dd HH:mm");
    }
}

public static class LinkedInScraperMapper
{
    public static Post[] Map(ScrapedPost? posts)
    {
        return posts?.Data
            .Select(p => Post.Create(p.Text ?? "", ParseDate(p.PostedDate ?? "")))
            .ToArray() ?? [];
    }
    
    public static Comment[] Map(ScrapedComment? comments, DateTime? postedAfter = null)
    {
        return comments?.Data
            .Select(p => Comment.Restore(p.Text ?? "", ParseDate(p.PostedDate ?? "")))
            .Where(c => c.PostedDate > (postedAfter ?? DateTime.MinValue))
            .ToArray() ?? [];
    }
    
    private static DateTime ParseDate(string date)
    {
        var formats = new[]
        {
            "yyyy-MM-dd HH:mm:ss.f zzz",
            "yyyy-MM-dd HH:mm:ss.ff zzz",
            "yyyy-MM-dd HH:mm:ss.fff zzz"
        };
        
        var dateOffset = DateTimeOffset.ParseExact(
            date.Replace(" UTC", ""),
            formats,
            CultureInfo.InvariantCulture
        );
        return dateOffset.UtcDateTime;
    }
}