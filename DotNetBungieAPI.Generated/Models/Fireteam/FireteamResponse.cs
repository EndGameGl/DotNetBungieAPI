namespace DotNetBungieAPI.Generated.Models.Fireteam;

public class FireteamResponse
{
    [JsonPropertyName("Summary")]
    public Fireteam.FireteamSummary Summary { get; set; }

    [JsonPropertyName("Members")]
    public List<Fireteam.FireteamMember> Members { get; set; }

    [JsonPropertyName("Alternates")]
    public List<Fireteam.FireteamMember> Alternates { get; set; }
}
