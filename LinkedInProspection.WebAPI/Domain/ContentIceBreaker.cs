using System.Text.Json.Serialization;

namespace LinkedInProspection.WebAPI.Domain;

public enum IceBreakerType
{
    Post,
    Comment,
    Article
}

public class ContentIceBreaker
{
    [JsonConstructor]
    private ContentIceBreaker(IceBreakerType type, string content, string[] iceBreakers)
    {
        Type = type;
        Content = content;
        IceBreakers = iceBreakers;
    }
    
    public IceBreakerType Type { get; }
    public string Content { get; }
    public string[] IceBreakers { get; }

    public static ContentIceBreaker Restore(IceBreakerType type, string content, string[] iceBreakers)
    {
        return new ContentIceBreaker(type, content, iceBreakers);
    }
}