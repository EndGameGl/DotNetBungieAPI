namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Activities;

/// <summary>
///     There are times in every Activity's life when interacting with an object in the world will result in another Activity activating. Well, not every Activity. Just certain ones.
/// <para />
///     Anyways, this defines a set of interactable components, the activities that they spawn when you interact with them, and the conditions under which they can be interacted with.
/// <para />
///     Sadly, we don't get any *really* good data for them, like positional data... yet. I have hopes for future data that we could put on this.
/// </summary>
public class DestinyActivityInteractableDefinition
{
    /// <summary>
    ///     The possible interactables in this activity interactable definition.
    /// </summary>
    [JsonPropertyName("entries")]
    public List<Destiny.Definitions.Activities.DestinyActivityInteractableEntryDefinition> Entries { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint? Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool? Redacted { get; set; }
}
