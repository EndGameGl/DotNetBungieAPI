using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Definitions
{
    public sealed record DestinyArtDyeReference : IDeepEquatable<DestinyArtDyeReference>
    {
        [JsonPropertyName("artDyeChannelHash")]
        public uint ArtDyeChannelHash { get; init; }

        public bool DeepEquals(DestinyArtDyeReference other)
        {
            return other != null && ArtDyeChannelHash.Equals(other.ArtDyeChannelHash);
        }
    }
}