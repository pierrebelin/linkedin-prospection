namespace LinkedInProspection.WebAPI.Domain;


public enum IceBreakerType
{
    Post,
    Comment,
    Article
}

public class IceBreaker
{
    private IceBreaker(IceBreakerType type, string content, string originalContent, string relatedUrl)
    {
        Type = type;
        Content = content;
        OriginalContent = originalContent;
        RelatedUrl = relatedUrl;
    }
    
    public IceBreakerType Type { get; }
    public string Content { get; }
    public string OriginalContent { get; }
    public string RelatedUrl { get; }

    public static IceBreaker Restore(IceBreakerType type, string content, string originalContent, string relatedUrl)
    {
        return new IceBreaker(type, content, originalContent, relatedUrl);
    }
}