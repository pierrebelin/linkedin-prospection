using LinkedInProspection.WebAPI.Domain;

namespace LinkedInProspection.WebAPI.Application.Interfaces;

public interface ILLMService
{
    Task<IceBreaker[]> GetIceBreakers(ProspectInformation prospectInformation);
}