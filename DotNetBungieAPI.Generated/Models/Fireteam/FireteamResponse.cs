namespace DotNetBungieAPI.Generated.Models.Fireteam;

public sealed class FireteamResponse
{

    [JsonPropertyName("Summary")]
    public Fireteam.FireteamSummary Summary { get; init; }

    [JsonPropertyName("Members")]
    public List<Fireteam.FireteamMember> Members { get; init; }

    [JsonPropertyName("Alternates")]
    public List<Fireteam.FireteamMember> Alternates { get; init; }
}
