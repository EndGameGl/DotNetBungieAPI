using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyActivityDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("originalDisplayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition OriginalDisplayProperties { get; init; }

    [JsonPropertyName("selectionScreenDisplayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition SelectionScreenDisplayProperties { get; init; }

    [JsonPropertyName("releaseIcon")]
    public string ReleaseIcon { get; init; }

    [JsonPropertyName("releaseTime")]
    public int ReleaseTime { get; init; }

    [JsonPropertyName("activityLightLevel")]
    public int ActivityLightLevel { get; init; }

    [JsonPropertyName("destinationHash")]
    public uint DestinationHash { get; init; }

    [JsonPropertyName("placeHash")]
    public uint PlaceHash { get; init; }

    [JsonPropertyName("activityTypeHash")]
    public uint ActivityTypeHash { get; init; }

    [JsonPropertyName("tier")]
    public int Tier { get; init; }

    [JsonPropertyName("pgcrImage")]
    public string PgcrImage { get; init; }

    [JsonPropertyName("rewards")]
    public List<Destiny.Definitions.DestinyActivityRewardDefinition> Rewards { get; init; }

    [JsonPropertyName("modifiers")]
    public List<Destiny.Definitions.DestinyActivityModifierReferenceDefinition> Modifiers { get; init; }

    [JsonPropertyName("isPlaylist")]
    public bool IsPlaylist { get; init; }

    [JsonPropertyName("challenges")]
    public List<Destiny.Definitions.DestinyActivityChallengeDefinition> Challenges { get; init; }

    [JsonPropertyName("optionalUnlockStrings")]
    public List<Destiny.Definitions.DestinyActivityUnlockStringDefinition> OptionalUnlockStrings { get; init; }

    [JsonPropertyName("playlistItems")]
    public List<Destiny.Definitions.DestinyActivityPlaylistItemDefinition> PlaylistItems { get; init; }

    [JsonPropertyName("activityGraphList")]
    public List<Destiny.Definitions.DestinyActivityGraphListEntryDefinition> ActivityGraphList { get; init; }

    [JsonPropertyName("matchmaking")]
    public Destiny.Definitions.DestinyActivityMatchmakingBlockDefinition Matchmaking { get; init; }

    [JsonPropertyName("guidedGame")]
    public Destiny.Definitions.DestinyActivityGuidedBlockDefinition GuidedGame { get; init; }

    [JsonPropertyName("directActivityModeHash")]
    public uint? DirectActivityModeHash { get; init; }

    [JsonPropertyName("directActivityModeType")]
    public int? DirectActivityModeType { get; init; }

    [JsonPropertyName("loadouts")]
    public List<Destiny.Definitions.DestinyActivityLoadoutRequirementSet> Loadouts { get; init; }

    [JsonPropertyName("activityModeHashes")]
    public List<uint> ActivityModeHashes { get; init; }

    [JsonPropertyName("activityModeTypes")]
    public List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> ActivityModeTypes { get; init; }

    [JsonPropertyName("isPvP")]
    public bool IsPvP { get; init; }

    [JsonPropertyName("insertionPoints")]
    public List<Destiny.Definitions.DestinyActivityInsertionPointDefinition> InsertionPoints { get; init; }

    [JsonPropertyName("activityLocationMappings")]
    public List<Destiny.Constants.DestinyEnvironmentLocationMapping> ActivityLocationMappings { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
