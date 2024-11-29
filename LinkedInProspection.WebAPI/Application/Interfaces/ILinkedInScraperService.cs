using LinkedInProspection.WebAPI.Domain;

namespace LinkedInProspection.WebAPI.Application.Interfaces;

public interface ILinkedInScraperService
{
    Task<Post[]> ScrapePosts(Username username, DateTime? postedAfter = null);
    Task<Comment[]> ScrapeComments(Username username, DateTime? postedAfter = null);
}