using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.InventoryItems
{
    public class InventoryItemTranslationBlockArrangement : IDeepEquatable<InventoryItemTranslationBlockArrangement>
    {
        public uint ArtArrangementHash { get; }
        public uint ClassHash { get; }

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
