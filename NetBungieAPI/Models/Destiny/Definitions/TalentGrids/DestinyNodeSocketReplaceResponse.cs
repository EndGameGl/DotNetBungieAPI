using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.SocketTypes;

namespace NetBungieAPI.Models.Destiny.Definitions.TalentGrids
{
    /// <summary>
    ///     This is a bit of an odd duck. Apparently, if talent nodes steps have this data, the game will go through on step
    ///     activation and alter the first Socket it finds on the item that has a type matching the given socket type,
    ///     inserting the indicated plug item.
    /// </summary>
    public sealed record DestinyNodeSocketReplaceResponse : IDeepEquatable<DestinyNodeSocketReplaceResponse>
    {
        /// <summary>
        ///     The hash identifier of the socket type to find amidst the item's sockets (the item to which this talent grid is
        ///     attached). See DestinyInventoryItemDefinition.sockets.socketEntries to find the socket type of sockets on the item
        ///     in question.
        /// </summary>
        [JsonPropertyName("socketTypeHash")]
        public DefinitionHashPointer<DestinySocketTypeDefinition> SocketType { get; init; } =
            DefinitionHashPointer<DestinySocketTypeDefinition>.Empty;

        /// <summary>
        ///     The hash identifier of the plug item that will be inserted into the socket found.
        /// </summary>
        [JsonPropertyName("plugItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        public bool DeepEquals(DestinyNodeSocketReplaceResponse other)
        {
            return other != null &&
                   SocketType.DeepEquals(other.SocketType) &&
                   PlugItem.DeepEquals(other.PlugItem);
        }
    }
}