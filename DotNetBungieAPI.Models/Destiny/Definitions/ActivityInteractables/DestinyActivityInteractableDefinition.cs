using DotNetBungieAPI.Models.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.ActivityInteractables;

/// <summary>
///     There are times in every Activity's life when interacting with an object in the world will result in another Activity activating. Well, not every Activity. Just certain ones.
///     <para />
///     Anyways, this defines a set of interactable components, the activities that they spawn when you interact with them, and the conditions under which they can be interacted with.
///     <para />
///     Sadly, we don't get any *really* good data for them, like positional data... yet. I have hopes for future data that we could put on this.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyActivityInteractableDefinition)]
public sealed record DestinyActivityInteractableDefinition : IDestinyDefinition
{
    /// <summary>
    ///     The possible interactables in this activity interactable definition.
    /// </summary>
    [JsonPropertyName("entries")]
    public ReadOnlyCollection<DestinyActivityInteractableEntryDefinition> Entries { get; init; } =
        ReadOnlyCollections<DestinyActivityInteractableEntryDefinition>.Empty;

    public DefinitionsEnum DefinitionEnumValue =>
        DefinitionsEnum.DestinyActivityInteractableDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
