namespace LinkedInProspection.WebAPI.Domain;

public class Comment
{
    private Comment(string text, DateTime postedDate)
    {
        Text = text;
        PostedDate = postedDate;
    }

    public string Text { get; }
    public DateTime PostedDate { get; }

    public static Comment Restore(string text, DateTime postedDate)
    {
        return new Comment(text, postedDate);
    }
}