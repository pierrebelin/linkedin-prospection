namespace LinkedInProspection.WebAPI.Domain;

public class Post
{
    private Post(string text, DateTime postedDate)
    {
        Text = text;
        PostedDate = postedDate;
    }

    public string Text { get; }
    public DateTime PostedDate { get; }

    public static Post Create(string text, DateTime postedDate)
    {
        return new Post(text, postedDate);
    }
}