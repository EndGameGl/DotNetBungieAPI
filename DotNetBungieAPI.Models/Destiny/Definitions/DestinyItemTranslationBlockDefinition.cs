﻿using DotNetBungieAPI.Models.Destiny.Definitions.SandboxPatterns;

namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     This Block defines the rendering data associated with the item, if any.
/// </summary>
public sealed record DestinyItemTranslationBlockDefinition
    : IDeepEquatable<DestinyItemTranslationBlockDefinition>
{
    [JsonPropertyName("weaponPatternIdentifier")]
    public string WeaponPatternIdentifier { get; init; }

    [JsonPropertyName("weaponPatternHash")]
    public DefinitionHashPointer<DestinySandboxPatternDefinition> WeaponPattern { get; init; } =
        DefinitionHashPointer<DestinySandboxPatternDefinition>.Empty;

    [JsonPropertyName("defaultDyes")]
    public ReadOnlyCollection<DyeReference> DefaultDyes { get; init; } =
        ReadOnlyCollection<DyeReference>.Empty;

    [JsonPropertyName("lockedDyes")]
    public ReadOnlyCollection<DyeReference> LockedDyes { get; init; } =
        ReadOnlyCollection<DyeReference>.Empty;

    [JsonPropertyName("customDyes")]
    public ReadOnlyCollection<DyeReference> CustomDyes { get; init; } =
        ReadOnlyCollection<DyeReference>.Empty;

    [JsonPropertyName("arrangements")]
    public ReadOnlyCollection<DestinyGearArtArrangementReference> Arrangements { get; init; } =
        ReadOnlyCollection<DestinyGearArtArrangementReference>.Empty;

    [JsonPropertyName("hasGeometry")]
    public bool HasGeometry { get; init; }

    public bool DeepEquals(DestinyItemTranslationBlockDefinition other)
    {
        return other != null
            && Arrangements.DeepEqualsReadOnlyCollection(other.Arrangements)
            && CustomDyes.DeepEqualsReadOnlyCollection(other.CustomDyes)
            && DefaultDyes.DeepEqualsReadOnlyCollection(other.DefaultDyes)
            && LockedDyes.DeepEqualsReadOnlyCollection(other.LockedDyes)
            && HasGeometry == other.HasGeometry
            && WeaponPattern.DeepEquals(other.WeaponPattern)
            && WeaponPatternIdentifier == other.WeaponPatternIdentifier;
    }
}
