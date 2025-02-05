﻿using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Checklists;

/// <summary>
///     By public demand, Checklists are loose sets of "things to do/things you have done" in Destiny that we were actually
///     able to track. They include easter eggs you find in the world, unique chests you unlock, and other such data where
///     the first time you do it is significant enough to be tracked, and you have the potential to "get them all".
///     <para />
///     These may be account-wide, or may be per character.The status of these will be returned in related "Checklist" data
///     coming down from API requests such as GetProfile or GetCharacter.
///     <para />
///     Generally speaking, the items in a checklist can be completed in any order: we return an ordered list which only
///     implies the way we are showing them in our own UI, and you can feel free to alter it as you wish.
///     <para />
///     Note that, in the future, there will be something resembling the old D1 Record Books in at least some vague
///     form.When that is created, it may be that it will supercede much or all of this Checklist data. It remains to be
///     seen if that will be the case, so for now assume that the Checklists will still exist even after the release of D2:
///     Forsaken.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyChecklistDefinition)]
public sealed record DestinyChecklistDefinition
    : IDestinyDefinition,
        IDisplayProperties,
        IDeepEquatable<DestinyChecklistDefinition>
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     The individual checklist items.
    /// </summary>
    [JsonPropertyName("entries")]
    public ReadOnlyCollection<DestinyChecklistEntryDefinition> Entries { get; init; } =
        ReadOnlyCollection<DestinyChecklistEntryDefinition>.Empty;

    /// <summary>
    ///     Indicates whether you will find this checklist on the Profile or Character components.
    /// </summary>
    [JsonPropertyName("scope")]
    public DestinyScope Scope { get; init; }

    /// <summary>
    ///     A localized string prompting you to view the checklist.
    /// </summary>
    [JsonPropertyName("viewActionString")]
    public string ViewActionString { get; init; }

    public bool DeepEquals(DestinyChecklistDefinition other)
    {
        return other != null
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && Entries.DeepEqualsReadOnlyCollection(other.Entries)
            && Scope == other.Scope
            && ViewActionString == other.ViewActionString
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyChecklistDefinition;

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
