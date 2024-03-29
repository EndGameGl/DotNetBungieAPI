namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     The response contract for GetDestinyCharacter, with components that can be returned for character and item-level data.
/// </summary>
public class DestinyCharacterResponse
{
    /// <summary>
    ///     The character-level non-equipped inventory items.
    /// <para />
    ///     COMPONENT TYPE: CharacterInventories
    /// </summary>
    [JsonPropertyName("inventory")]
    public SingleComponentResponseOfDestinyInventoryComponent? Inventory { get; set; }

    /// <summary>
    ///     Base information about the character in question.
    /// <para />
    ///     COMPONENT TYPE: Characters
    /// </summary>
    [JsonPropertyName("character")]
    public SingleComponentResponseOfDestinyCharacterComponent? Character { get; set; }

    /// <summary>
    ///     Character progression data, including Milestones.
    /// <para />
    ///     COMPONENT TYPE: CharacterProgressions
    /// </summary>
    [JsonPropertyName("progressions")]
    public SingleComponentResponseOfDestinyCharacterProgressionComponent? Progressions { get; set; }

    /// <summary>
    ///     Character rendering data - a minimal set of information about equipment and dyes used for rendering.
    /// <para />
    ///     COMPONENT TYPE: CharacterRenderData
    /// </summary>
    [JsonPropertyName("renderData")]
    public SingleComponentResponseOfDestinyCharacterRenderComponent? RenderData { get; set; }

    /// <summary>
    ///     Activity data - info about current activities available to the player.
    /// <para />
    ///     COMPONENT TYPE: CharacterActivities
    /// </summary>
    [JsonPropertyName("activities")]
    public SingleComponentResponseOfDestinyCharacterActivitiesComponent? Activities { get; set; }

    /// <summary>
    ///     Equipped items on the character.
    /// <para />
    ///     COMPONENT TYPE: CharacterEquipment
    /// </summary>
    [JsonPropertyName("equipment")]
    public SingleComponentResponseOfDestinyInventoryComponent? Equipment { get; set; }

    /// <summary>
    ///     The loadouts available to the character.
    /// <para />
    ///     COMPONENT TYPE: CharacterLoadouts
    /// </summary>
    [JsonPropertyName("loadouts")]
    public SingleComponentResponseOfDestinyLoadoutsComponent? Loadouts { get; set; }

    /// <summary>
    ///     Items available from Kiosks that are available to this specific character. 
    /// <para />
    ///     COMPONENT TYPE: Kiosks
    /// </summary>
    [JsonPropertyName("kiosks")]
    public SingleComponentResponseOfDestinyKiosksComponent? Kiosks { get; set; }

    /// <summary>
    ///     When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and their states that are scoped to this character.
    /// <para />
    ///     This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
    /// <para />
    ///     COMPONENT TYPE: ItemSockets
    /// </summary>
    [JsonPropertyName("plugSets")]
    public SingleComponentResponseOfDestinyPlugSetsComponent? PlugSets { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: PresentationNodes
    /// </summary>
    [JsonPropertyName("presentationNodes")]
    public SingleComponentResponseOfDestinyPresentationNodesComponent? PresentationNodes { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: Records
    /// </summary>
    [JsonPropertyName("records")]
    public SingleComponentResponseOfDestinyCharacterRecordsComponent? Records { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: Collectibles
    /// </summary>
    [JsonPropertyName("collectibles")]
    public SingleComponentResponseOfDestinyCollectiblesComponent? Collectibles { get; set; }

    /// <summary>
    ///     The set of components belonging to the player's instanced items.
    /// <para />
    ///     COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
    /// </summary>
    [JsonPropertyName("itemComponents")]
    public DestinyItemComponentSetOfint64? ItemComponents { get; set; }

    /// <summary>
    ///     The set of components belonging to the player's UNinstanced items. Because apparently now those too can have information relevant to the character's state.
    /// <para />
    ///     COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
    /// </summary>
    [JsonPropertyName("uninstancedItemComponents")]
    public DestinyBaseItemComponentSetOfuint32? UninstancedItemComponents { get; set; }

    /// <summary>
    ///     A "lookup" convenience component that can be used to quickly check if the character has access to items that can be used for purchasing.
    /// <para />
    ///     COMPONENT TYPE: CurrencyLookups
    /// </summary>
    [JsonPropertyName("currencyLookups")]
    public SingleComponentResponseOfDestinyCurrenciesComponent? CurrencyLookups { get; set; }
}
