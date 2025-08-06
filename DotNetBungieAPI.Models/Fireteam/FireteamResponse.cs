namespace DotNetBungieAPI.Models.Fireteam;

public sealed class FireteamResponse
{
    [JsonPropertyName("Summary")]
    public Fireteam.FireteamSummary? Summary { get; init; }

    [JsonPropertyName("Members")]
    public Fireteam.FireteamMember[]? Members { get; init; }

    [JsonPropertyName("Alternates")]
    public Fireteam.FireteamMember[]? Alternates { get; init; }
}
