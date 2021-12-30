using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyActivityMatchmakingBlockDefinition
{

    [JsonPropertyName("isMatchmade")]
    public bool IsMatchmade { get; init; }

    [JsonPropertyName("minParty")]
    public int MinParty { get; init; }

    [JsonPropertyName("maxParty")]
    public int MaxParty { get; init; }

    [JsonPropertyName("maxPlayers")]
    public int MaxPlayers { get; init; }

    [JsonPropertyName("requiresGuardianOath")]
    public bool RequiresGuardianOath { get; init; }
}
