using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    public sealed record DestinyAnimationReference : IDeepEquatable<DestinyAnimationReference>
    {
        [JsonPropertyName("animName")] public string Name { get; init; }

        [JsonPropertyName("animIdentifier")] public string Identifier { get; init; }

        [JsonPropertyName("path")] public string Path { get; init; }

        public bool DeepEquals(DestinyAnimationReference other)
        {
            return other != null &&
                   Name == other.Name &&
                   Identifier == other.Identifier &&
                   Path == other.Path;
        }
    }
}