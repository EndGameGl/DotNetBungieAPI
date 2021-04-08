using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemAnimationReference : IDeepEquatable<InventoryItemAnimationReference>
    {
        public string Name { get; init; }
        public string Identifier { get; init; }
        public string Path { get; init; }

        [JsonConstructor]
        internal InventoryItemAnimationReference(string animName, string animIdentifier, string path)
        {
            Name = animName;
            Identifier = animIdentifier;
            Path = path;
        }

        public bool DeepEquals(InventoryItemAnimationReference other)
        {
            return other != null &&
                   Name == other.Name &&
                   Identifier == other.Identifier &&
                   Path == other.Path;
        }
    }
}
