namespace LinkedInProspection.WebAPI.Domain;

public class ProspectInformation
{
    public Post[] Posts { get; }
    public Comment[] Comments { get; }

    private ProspectInformation(Post[] posts, Comment[] comments)
    {
        Posts = posts;
        Comments = comments;
    }

    public static ProspectInformation Restore(Post[] posts, Comment[] comments)
    {
        return new ProspectInformation(posts, comments);
    }
}