using System.Text.Json.Serialization;

namespace LinkedInProspection.WebAPI.Infrastructure.LinkedInScraper;

public class Author
{
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}

public class Image
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }
}

public class Video
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("poster")]
    public string? Poster { get; set; }

    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}

public class Company
{
    // Empty class preserved
}

public class Article
{
    // Empty class preserved
}
