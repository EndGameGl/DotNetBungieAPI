using DotNetBungieAPI.Models.Destiny.Definitions.Unlocks;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

public sealed record SchemaRecordStateBlock : IDeepEquatable<SchemaRecordStateBlock>
{
    [JsonPropertyName("claimedUnlockHash")]
    public DefinitionHashPointer<DestinyUnlockDefinition> ClaimedUnlock { get; init; } =
        DefinitionHashPointer<DestinyUnlockDefinition>.Empty;

    [JsonPropertyName("completeUnlockHash")]
    public DefinitionHashPointer<DestinyUnlockDefinition> CompleteUnlock { get; init; } =
        DefinitionHashPointer<DestinyUnlockDefinition>.Empty;

    [JsonPropertyName("featuredPriority")]
    public int FeaturedPriority { get; init; }

    /// <summary>
    ///     A display name override to show when this record is 'obscured' instead of the default obscured display name.
    /// </summary>
    [JsonPropertyName("obscuredName")]
    public string ObscuredName { get; set; }

    /// <summary>
    ///     A display description override to show when this record is 'obscured' instead of the default obscured display description.
    /// </summary>
    [JsonPropertyName("obscuredDescription")]
    public string ObscuredDescription { get; set; }

    public bool DeepEquals(SchemaRecordStateBlock other)
    {
        return other != null
            && ClaimedUnlock.DeepEquals(other.ClaimedUnlock)
            && CompleteUnlock.DeepEquals(other.CompleteUnlock)
            && FeaturedPriority == other.FeaturedPriority
            && ObscuredName == other.ObscuredName
            && ObscuredDescription == other.ObscuredDescription;
    }
}
