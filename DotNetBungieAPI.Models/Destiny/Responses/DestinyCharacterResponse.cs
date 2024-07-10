using DotNetBungieAPI.Models.Destiny.Components;

namespace DotNetBungieAPI.Models.Destiny.Responses;

/// <summary>
///     The response contract for GetDestinyCharacter, with components that can be returned for character and item-level
///     data.
/// </summary>
public sealed record DestinyCharacterResponse
{
    /// <summary>
    ///     The character-level non-equipped inventory items.
    /// </summary>
    [JsonPropertyName("inventory")]
    public SingleComponentResponseOfDestinyInventoryComponent Inventory { get; init; }

    /// <summary>
    ///     Base information about the character in question.
    /// </summary>
    [JsonPropertyName("character")]
    public SingleComponentResponseOfDestinyCharacterComponent Character { get; init; }

    /// <summary>
    ///     Character progression data, including Milestones.
    /// </summary>
    [JsonPropertyName("progressions")]
    public SingleComponentResponseOfDestinyCharacterProgressionComponent Progressions { get; init; }

    /// <summary>
    ///     Character rendering data - a minimal set of information about equipment and dyes used for rendering.
    /// </summary>
    [JsonPropertyName("renderData")]
    public SingleComponentResponseOfDestinyCharacterRenderComponent RenderData { get; init; }

    /// <summary>
    ///     Activity data - info about current activities available to the player.
    /// </summary>
    [JsonPropertyName("activities")]
    public SingleComponentResponseOfDestinyCharacterActivitiesComponent Activities { get; init; }

    /// <summary>
    ///     Equipped items on the character.
    /// </summary>
    [JsonPropertyName("equipment")]
    public SingleComponentResponseOfDestinyInventoryComponent Equipment { get; init; }

    /// <summary>
    ///     The loadouts available to the character.
    /// <para />
    ///     COMPONENT TYPE: CharacterLoadouts
    /// </summary>
    [JsonPropertyName("loadouts")]
    public SingleComponentResponseOfDestinyLoadoutsComponent Loadouts { get; init; }

    /// <summary>
    ///     Items available from Kiosks that are available to this specific character.
    /// </summary>
    [JsonPropertyName("kiosks")]
    public SingleComponentResponseOfDestinyKiosksComponent Kiosks { get; init; }

    /// <summary>
    ///     When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and
    ///     their states that are scoped to this character.
    ///     <para />
    ///     This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
    /// </summary>
    [JsonPropertyName("plugSets")]
    public SingleComponentResponseOfDestinyPlugSetsComponent PlugSets { get; init; }

    [JsonPropertyName("presentationNodes")]
    public SingleComponentResponseOfDestinyPresentationNodesComponent PresentationNodes { get; init; }

    [JsonPropertyName("records")]
    public SingleComponentResponseOfDestinyCharacterRecordsComponent Records { get; init; }

    [JsonPropertyName("collectibles")]
    public SingleComponentResponseOfDestinyCollectiblesComponent Collectibles { get; init; }

    /// <summary>
    ///     The set of components belonging to the player's instanced items.
    /// </summary>
    [JsonPropertyName("itemComponents")]
    public DestinyItemComponentSetOfint64 ItemComponents { get; init; }

    /// <summary>
    ///     The set of components belonging to the player's UNinstanced items. Because apparently now those too can have
    ///     information relevant to the character's state.
    /// </summary>
    [JsonPropertyName("uninstancedItemComponents")]
    public DestinyBaseItemComponentSetOfuint32 UninstancedItemComponents { get; init; }

    /// <summary>
    ///     A "lookup" convenience component that can be used to quickly check if the character has access to items that can be
    ///     used for purchasing.
    /// </summary>
    [JsonPropertyName("currencyLookups")]
    public SingleComponentResponseOfDestinyCurrenciesComponent CurrencyLookups { get; init; }
}
