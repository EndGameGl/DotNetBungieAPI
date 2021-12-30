using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sockets;

/// <summary>
///     Sockets on an item are organized into Categories visually.
/// <para />
///     You can find references to the socket category defined on an item's DestinyInventoryItemDefinition.sockets.socketCategories property.
/// <para />
///     This has the display information for rendering the categories' header, and a hint for how the UI should handle showing this category.
/// <para />
///     The shitty thing about this, however, is that the socket categories' UI style can be overridden by the item's UI style. For instance, the Socket Category used by Emote Sockets says it's "consumable," but that's a lie: they're all reusable, and overridden by the detail UI pages in ways that we can't easily account for in the API.
/// <para />
///     As a result, I will try to compile these rules into the individual sockets on items, and provide the best hint possible there through the plugSources property. In the future, I may attempt to use this information in conjunction with the item to provide a more usable UI hint on the socket layer, but for now improving the consistency of plugSources is the best I have time to provide. (See https://github.com/Bungie-net/api/issues/522 for more info)
/// </summary>
public sealed class DestinySocketCategoryDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     A string hinting to the game's UI system about how the sockets in this category should be displayed.
    /// <para />
    ///     BNet doesn't use it: it's up to you to find valid values and make your own special UI if you want to honor this category style.
    /// </summary>
    [JsonPropertyName("uiCategoryStyle")]
    public uint UiCategoryStyle { get; init; }

    /// <summary>
    ///     Same as uiCategoryStyle, but in a more usable enumeration form.
    /// </summary>
    [JsonPropertyName("categoryStyle")]
    public Destiny.DestinySocketCategoryStyle CategoryStyle { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
