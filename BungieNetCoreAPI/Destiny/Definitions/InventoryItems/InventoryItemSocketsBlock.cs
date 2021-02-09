using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// If defined, the item has at least one socket.
    /// </summary>
    public class InventoryItemSocketsBlock : IDeepEquatable<InventoryItemSocketsBlock>
    {
        /// <summary>
        /// This was supposed to be a string that would give per-item details about sockets. In practice, it turns out that all this ever has is the localized word "details".
        /// </summary>
        public string Detail { get; }
        /// <summary>
        /// Each intrinsic (or immutable/permanent) socket on an item is defined here, along with the plug that is permanently affixed to the socket.
        /// </summary>
        public ReadOnlyCollection<InventoryItemSocketsBlockIntrinsicSocket> IntrinsicSockets { get; }
        /// <summary>
        /// A convenience property, that refers to the sockets in the "sockets" property, pre-grouped by category and ordered in the manner that they should be grouped in the UI.
        /// </summary>
        public ReadOnlyCollection<InventoryItemSocketsBlockSocketCategory> SocketCategories { get; }
        /// <summary>
        /// Each non-intrinsic (or mutable) socket on an item is defined here.
        /// </summary>
        public ReadOnlyCollection<InventoryItemSocketsBlockSocketEntry> SocketEntries { get; }

        [JsonConstructor]
        internal InventoryItemSocketsBlock(string detail, InventoryItemSocketsBlockIntrinsicSocket[] intrinsicSockets, InventoryItemSocketsBlockSocketCategory[] socketCategories,
            InventoryItemSocketsBlockSocketEntry[] socketEntries)
        {
            Detail = detail;
            IntrinsicSockets = intrinsicSockets.AsReadOnlyOrEmpty();
            SocketCategories = socketCategories.AsReadOnlyOrEmpty();
            SocketEntries = socketEntries.AsReadOnlyOrEmpty();
        }
        public bool DeepEquals(InventoryItemSocketsBlock other)
        {
            return other != null &&
                   Detail == other.Detail &&
                   IntrinsicSockets.DeepEqualsReadOnlyCollections(other.IntrinsicSockets) &&
                   SocketCategories.DeepEqualsReadOnlyCollections(other.SocketCategories) &&
                   SocketEntries.DeepEqualsReadOnlyCollections(other.SocketEntries);
        }
        public override string ToString()
        {
            return $"{SocketEntries.Count} sockets available.";
        }
    }
}
