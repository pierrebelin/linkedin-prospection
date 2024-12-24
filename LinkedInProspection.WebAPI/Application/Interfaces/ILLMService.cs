using LinkedInProspection.WebAPI.Domain;

namespace LinkedInProspection.WebAPI.Application.Interfaces;

public interface ILLMService
{
    Task<ContentIceBreaker[]> GetIceBreakers(ProspectInformation prospectInformation);
}