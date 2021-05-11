using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.SocketCategories
{
    /// <summary>
    /// Sockets on an item are organized into Categories visually.
    /// <para/>
    /// You can find references to the socket category defined on an item's DestinyInventoryItemDefinition.sockets.socketCategories property.
    /// <para/>
    /// This has the display information for rendering the categories' header, and a hint for how the UI should handle showing this category.
    /// <para/>
    /// The shitty thing about this, however, is that the socket categories' UI style can be overridden by the item's UI style. For instance, the Socket Category used by Emote Sockets says it's "consumable," but that's a lie: they're all reusable, and overridden by the detail UI pages in ways that we can't easily account for in the API.
    /// <para/>
    /// As a result, I will try to compile these rules into the individual sockets on items, and provide the best hint possible there through the plugSources property. In the future, I may attempt to use this information in conjunction with the item to provide a more usable UI hint on the socket layer, but for now improving the consistency of plugSources is the best I have time to provide.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinySocketCategoryDefinition)]
    public sealed record DestinySocketCategoryDefinition : IDestinyDefinition,
        IDeepEquatable<DestinySocketCategoryDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        /// Same as uiCategoryStyle, but in a more usable enumeration form.
        /// </summary>
        [JsonPropertyName("categoryStyle")]
        public DestinySocketCategoryStyle CategoryStyle { get; init; }

        /// <summary>
        /// A string hinting to the game's UI system about how the sockets in this category should be displayed.
        /// <para/>
        /// BNet doesn't use it: it's up to you to find valid values and make your own special UI if you want to honor this category style.
        /// </summary>
        [JsonPropertyName("uiCategoryStyle")]
        public uint UiCategoryStyle { get; init; }

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public void MapValues()
        {
            return;
        }

        public bool DeepEquals(DestinySocketCategoryDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   CategoryStyle == other.CategoryStyle &&
                   UiCategoryStyle == other.UiCategoryStyle &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}