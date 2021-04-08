using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemTranslationBlockArrangement : IDeepEquatable<InventoryItemTranslationBlockArrangement>
    {
        public uint ArtArrangementHash { get; init; }
        public uint ClassHash { get; init; }

        [JsonConstructor]
        internal InventoryItemTranslationBlockArrangement(uint artArrangementHash, uint classHash)
        {
            ArtArrangementHash = artArrangementHash;
            ClassHash = classHash;
        }

        public bool DeepEquals(InventoryItemTranslationBlockArrangement other)
        {
            return other != null &&
                  ArtArrangementHash == other.ArtArrangementHash &&
                  ClassHash == other.ClassHash;
        }
    }
}
