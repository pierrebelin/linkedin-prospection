namespace LinkedInProspection.WebAPI.Domain;

public class Username
{
    private Username(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Username Create(string value)
    {
        return new Username(value);
    }
}