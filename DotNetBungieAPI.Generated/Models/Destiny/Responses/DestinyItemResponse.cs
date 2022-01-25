namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     The response object for retrieving an individual instanced item. None of these components are relevant for an item that doesn't have an "itemInstanceId": for those, get your information from the DestinyInventoryDefinition.
/// </summary>
public class DestinyItemResponse
{
    /// <summary>
    ///     If the item is on a character, this will return the ID of the character that is holding the item.
    /// </summary>
    [JsonPropertyName("characterId")]
    public long? CharacterId { get; set; }

    /// <summary>
    ///     Common data for the item relevant to its non-instanced properties.
    /// <para />
    ///     COMPONENT TYPE: ItemCommonData
    /// </summary>
    [JsonPropertyName("item")]
    public SingleComponentResponseOfDestinyItemComponent Item { get; set; }

    /// <summary>
    ///     Basic instance data for the item.
    /// <para />
    ///     COMPONENT TYPE: ItemInstances
    /// </summary>
    [JsonPropertyName("instance")]
    public SingleComponentResponseOfDestinyItemInstanceComponent Instance { get; set; }

    /// <summary>
    ///     Information specifically about the item's objectives.
    /// <para />
    ///     COMPONENT TYPE: ItemObjectives
    /// </summary>
    [JsonPropertyName("objectives")]
    public SingleComponentResponseOfDestinyItemObjectivesComponent Objectives { get; set; }

    /// <summary>
    ///     Information specifically about the perks currently active on the item.
    /// <para />
    ///     COMPONENT TYPE: ItemPerks
    /// </summary>
    [JsonPropertyName("perks")]
    public SingleComponentResponseOfDestinyItemPerksComponent Perks { get; set; }

    /// <summary>
    ///     Information about how to render the item in 3D.
    /// <para />
    ///     COMPONENT TYPE: ItemRenderData
    /// </summary>
    [JsonPropertyName("renderData")]
    public SingleComponentResponseOfDestinyItemRenderComponent RenderData { get; set; }

    /// <summary>
    ///     Information about the computed stats of the item: power, defense, etc...
    /// <para />
    ///     COMPONENT TYPE: ItemStats
    /// </summary>
    [JsonPropertyName("stats")]
    public SingleComponentResponseOfDestinyItemStatsComponent Stats { get; set; }

    /// <summary>
    ///     Information about the talent grid attached to the item. Talent nodes can provide a variety of benefits and abilities, and in Destiny 2 are used almost exclusively for the character's "Builds".
    /// <para />
    ///     COMPONENT TYPE: ItemTalentGrids
    /// </summary>
    [JsonPropertyName("talentGrid")]
    public SingleComponentResponseOfDestinyItemTalentGridComponent TalentGrid { get; set; }

    /// <summary>
    ///     Information about the sockets of the item: which are currently active, what potential sockets you could have and the stats/abilities/perks you can gain from them.
    /// <para />
    ///     COMPONENT TYPE: ItemSockets
    /// </summary>
    [JsonPropertyName("sockets")]
    public SingleComponentResponseOfDestinyItemSocketsComponent Sockets { get; set; }

    /// <summary>
    ///     Information about the Reusable Plugs for sockets on an item. These are plugs that you can insert into the given socket regardless of if you actually own an instance of that plug: they are logic-driven plugs rather than inventory-driven.
    /// <para />
    ///      These may need to be combined with Plug Set component data to get a full picture of available plugs on a given socket.
    /// <para />
    ///      COMPONENT TYPE: ItemReusablePlugs
    /// </summary>
    [JsonPropertyName("reusablePlugs")]
    public SingleComponentResponseOfDestinyItemReusablePlugsComponent ReusablePlugs { get; set; }

    /// <summary>
    ///     Information about objectives on Plugs for a given item. See the component's documentation for more info.
    /// <para />
    ///     COMPONENT TYPE: ItemPlugObjectives
    /// </summary>
    [JsonPropertyName("plugObjectives")]
    public SingleComponentResponseOfDestinyItemPlugObjectivesComponent PlugObjectives { get; set; }
}
