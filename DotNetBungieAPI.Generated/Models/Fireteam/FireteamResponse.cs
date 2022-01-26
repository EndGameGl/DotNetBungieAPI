namespace DotNetBungieAPI.Generated.Models.Fireteam;

public class FireteamResponse : IDeepEquatable<FireteamResponse>
{
    [JsonPropertyName("Summary")]
    public Fireteam.FireteamSummary Summary { get; set; }

    [JsonPropertyName("Members")]
    public List<Fireteam.FireteamMember> Members { get; set; }

    [JsonPropertyName("Alternates")]
    public List<Fireteam.FireteamMember> Alternates { get; set; }

    public bool DeepEquals(FireteamResponse? other)
    {
        return other is not null &&
               (Summary is not null ? Summary.DeepEquals(other.Summary) : other.Summary is null) &&
               Members.DeepEqualsList(other.Members) &&
               Alternates.DeepEqualsList(other.Alternates);
    }
}