using LinkedInProspection.WebAPI.Application.Core;
using LinkedInProspection.WebAPI.Domain;

namespace LinkedInProspection.WebAPI.Application.GenerateIceBreakers;

public class GenerateIceBreakerQuery : IQuery
{
    private GenerateIceBreakerQuery(Username username, DateTime postedAfter)
    {
        Username = username;
        PostedAfter = postedAfter;
    }
    
    public Username Username { get; }
    public DateTime PostedAfter { get; }

    public static GenerateIceBreakerQuery Create(string username, string postedAfter)
    {
        return new GenerateIceBreakerQuery(Username.Create(username), DateTime.Parse(postedAfter));
    }
}

public record GenerateIceBreakerResponse(ContentIceBreaker[] IceBreakers);