using System.Text.Json.Serialization;

namespace LinkedInProspection.WebAPI.Infrastructure.LinkedInScraper;

public class ScrapedComment
{
   [JsonPropertyName("success")]
   public bool Success { get; set; }

   [JsonPropertyName("message")]
   public string? Message { get; set; }

   [JsonPropertyName("data")]
   public ScrapedCommentContent[] Data { get; set; } = [];
}

public class ScrapedCommentContent
{
   [JsonPropertyName("highlightedComments")]
   public string[] HighlightedComments { get; set; } = [];

   [JsonPropertyName("highlightedCommentsActivityCounts")]
   public HighlightedCommentsActivityCounts[] HighlightedCommentsActivityCounts { get; set; } = [];

   [JsonPropertyName("text")]
   public string? Text { get; set; }

   [JsonPropertyName("commentUrl")]
   public string? CommentUrl { get; set; }

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

   [JsonPropertyName("funnyCount")]
   public int FunnyCount { get; set; }

   [JsonPropertyName("maybeCount")]
   public int MaybeCount { get; set; }

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

   [JsonPropertyName("commentedDate")]
   public string? CommentedDate { get; set; }

   [JsonPropertyName("urn")]
   public string? Urn { get; set; }

   [JsonPropertyName("author")]
   public Author? Author { get; set; }

   [JsonPropertyName("video")]
   public Video[] Video { get; set; } = [];

   [JsonPropertyName("company")]
   public Company? Company { get; set; }

   [JsonPropertyName("article")]
   public Article? Article { get; set; }
}

public class HighlightedCommentsActivityCounts
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

   [JsonPropertyName("maybeCount")]
   public int MaybeCount { get; set; }
}