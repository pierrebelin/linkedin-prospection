using System.Text.Json;
using LinkedInProspection.WebAPI.Application.Interfaces;
using LinkedInProspection.WebAPI.Domain;

namespace LinkedInProspection.WebAPI.Infrastructure.LLM;

public record ClaudeMessage(string Role, string Content);
public record ClaudeRequest(string Model, int MaxTokens, ClaudeMessage[] Messages);
public record ClaudeResponse(string Content);
public record IceBreakerResponse(string Type, string Content, string OriginalContent);

public class ClaudeLLMService : ILLMService
{
    private readonly HttpClient _httpClient;
    private const string MODEL = "claude-3-5-sonnet-20241022";
    
    public ClaudeLLMService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        var apiKey = configuration["Anthropic:ApiKey"] 
                      ?? throw new ArgumentNullException(nameof(configuration));
            
        _httpClient.BaseAddress = new Uri("https://api.anthropic.com/v1/");
        _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        _httpClient.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");
    }

    private const string ICE_BREAKERS_PROMPT_TEMPLATE = @"
    Tu es un expert d'icebreaker. 
    Ton rôle est de sélectionner les posts et les commentaires qui sont les plus pertinents pour trouver les icebreakers.
    Dans un premier temps, tu sélectionnes 6 éléments maximum parmi les posts et les commentaires qui sont les plus pertinents pour trouver les icebreakers.
    Ensuite, pour chaque élément, tu produiras 3 icebreakers différents.

    Voici un exemple d'icebreaker :
    Exemple 1 : 
       Commentaire : Déjà 4 mois que nos premiers Agents IA chez Phacet sont lives.

Depuis, plus de 48.000 opérations internes ont été déléguées de manière supervisée à nos Agents IA chez nos clients - en Finance & Comptabilité, RH, Opérations, Support Client, et gestion de catalogue ecommerce.

💡 Pour continuer à développer l'inventaire d'Agents disponibles sur Phacet nous agrandissons l'équipe et recherchons des Software Engineers. 

👉 pour développer des pipelines de données en temps réel pour orchestrer des tâches à grande échelle entre des systèmes existants.

👉 concevoir des interfaces d'intégration universelle permettant aux utilisateurs de déléguer des tâches à leurs Agents IA avec un simple clic depuis leur environnement habituel (Excel, API, emails, etc.).

👉 optimiser les performances des modèles prédictifs et génératifs en assemblant des workflows intégrés directement dans les processus métiers des clients.

👉 créer des systèmes de supervision IA où l’humain valide les résultats via une interaction fluide et sécurisée. 

       Icebreaker : Hello {nom}, bravo pour cette première étape des 48.000 opérations déléguées via des agents IA, c’est impressionnant. Es-tu disponible cette semaine pour échanger à ce sujet ?

    Voici les informations du prospect :
    Posts LinkedIn : {postsLinkedIn}
    Commentaires LinkedIn : {commentairesLinkedIn}

    Retourne UNIQUEMENT un objet JSON avec ce format exact, sans explications :
    {
        ""type"": ""post ou comment"",
        ""content"": ""icebreaker_ici"",
        ""originalContent"": ""contenu_relatif_a_l'icebreaker""
    }
    ";

    public async Task<IceBreaker[]> GetIceBreakers(ProspectInformation prospectInformation)
    {
        var iceBreakersPrompt = ICE_BREAKERS_PROMPT_TEMPLATE
            .Replace("{postsLinkedIn}", JsonSerializer.Serialize(prospectInformation.Posts))
            .Replace("{commentairesLinkedIn}", JsonSerializer.Serialize(prospectInformation.Comments));
        
        var request = new ClaudeRequest(
            Model: MODEL,
            MaxTokens: 1024,
            Messages: [
                new ClaudeMessage("user", iceBreakersPrompt),
            ]
        );

        var response = await _httpClient.PostAsJsonAsync("messages", request);
        response.EnsureSuccessStatusCode();
        
        var result = await response.Content.ReadFromJsonAsync<ClaudeResponse>();
        var content = JsonSerializer.Deserialize<IceBreakerResponse[]>(result!.Content);
        return content?.Select(c => IceBreaker.Restore(IceBreakerType.Post, c.Content, c.OriginalContent, c.Type))
            .ToArray() ?? [];
    }
}