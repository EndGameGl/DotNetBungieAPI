using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Definitions
{
    public sealed record DestinyGearArtArrangementReference : IDeepEquatable<DestinyGearArtArrangementReference>
    {
        [JsonPropertyName("artArrangementHash")]
        public uint ArtArrangementHash { get; init; }

        [JsonPropertyName("classHash")] public uint ClassHash { get; init; }

        public bool DeepEquals(DestinyGearArtArrangementReference other)
        {
            return other != null &&
                   ArtArrangementHash == other.ArtArrangementHash &&
                   ClassHash == other.ClassHash;
        }
    }
}