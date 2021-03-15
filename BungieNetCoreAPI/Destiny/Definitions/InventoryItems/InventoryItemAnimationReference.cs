using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemAnimationReference : IDeepEquatable<InventoryItemAnimationReference>
    {
        public string Name { get; }
        public string Identifier { get; }
        public string Path { get; }

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
