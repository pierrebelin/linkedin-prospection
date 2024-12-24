using System.Text.Json.Serialization;

namespace LinkedInProspection.WebAPI.Domain;

public class Post
{
    [JsonConstructor]
    private Post(string text, DateTime postedDate)
    {
        Text = text;
        PostedDate = postedDate;
    }

    public string Text { get; }
    public DateTime PostedDate { get; }

    public static Post Restore(string text, DateTime postedDate)
    {
        return new Post(text, postedDate);
    }
}