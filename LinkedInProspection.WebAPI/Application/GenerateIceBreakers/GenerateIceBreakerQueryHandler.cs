using LinkedInProspection.WebAPI.Application.Core;

namespace LinkedInProspection.WebAPI.Application.GenerateIceBreakers;

public interface IGenerateIceBreakerQueryHandler : IHandler<GenerateIceBreakerQuery, GenerateIceBreakerResponse>;
public class GenerateIceBreakerQueryHandler(RetrieverService retrieverService) : IGenerateIceBreakerQueryHandler
{
    public async Task<GenerateIceBreakerResponse> Handle(GenerateIceBreakerQuery query)
    {
        var iceBreakers = await retrieverService.GenerateIceBreakers(query.Username, query.PostedAfter);
        return new GenerateIceBreakerResponse(iceBreakers);
    }
}