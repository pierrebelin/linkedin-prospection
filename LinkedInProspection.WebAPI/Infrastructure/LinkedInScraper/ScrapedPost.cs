using System.Text.Json.Serialization;

namespace LinkedInProspection.WebAPI.Infrastructure.LinkedInScraper;

public class ScrapedPost
{
   [JsonPropertyName("success")]
   public bool Success { get; set; }

   [JsonPropertyName("message")] 
   public string? Message { get; set; }

   [JsonPropertyName("data")]
   public ScrapedPostContent[] Data { get; set; } = [];

   [JsonPropertyName("paginationToken")]
   public string? PaginationToken { get; set; }
}

public class ScrapedPostContent
{
   [JsonPropertyName("text")]
   public string? Text { get; set; }

   [JsonPropertyName("totalReactionCount")]
   public int TotalReactionCount { get; set; }

   [JsonPropertyName("likeCount")]
   public int LikeCount { get; set; }

   [JsonPropertyName("appreciationCount")]
   public int AppreciationCount { get; set; }

   [JsonPropertyName("empathyCount")]
   public int EmpathyCount { get; set; }

   [JsonPropertyName("InterestCount")]
   public int InterestCount { get; set; }

   [JsonPropertyName("praiseCount")]
   public int PraiseCount { get; set; }

   [JsonPropertyName("commentsCount")]
   public int CommentsCount { get; set; }

   [JsonPropertyName("repostsCount")]
   public int RepostsCount { get; set; }

   [JsonPropertyName("postUrl")]
   public string? PostUrl { get; set; }

   [JsonPropertyName("postedAt")]
   public string? PostedAt { get; set; }

   [JsonPropertyName("postedDate")]
   public string? PostedDate { get; set; }

   [JsonPropertyName("postedDateTimestamp")]
   public long PostedDateTimestamp { get; set; }

   [JsonPropertyName("reposted")]
   public bool Reposted { get; set; }

   [JsonPropertyName("urn")]
   public string? Urn { get; set; }

   [JsonPropertyName("author")]
   public Author? Author { get; set; }

   [JsonPropertyName("image")]
   public Image[] Image { get; set; } = [];

   [JsonPropertyName("company")]
   public Company? Company { get; set; }

   [JsonPropertyName("article")]
   public Article? Article { get; set; }
}