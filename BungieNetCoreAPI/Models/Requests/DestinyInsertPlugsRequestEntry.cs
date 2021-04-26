using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Requests
{
    public sealed class DestinyInsertPlugsRequestEntry
    {
        [JsonPropertyName("socketIndex")]
        public int SocketIndex { get; }
        [JsonPropertyName("socketArrayType")]
        public DestinySocketArrayType SocketArrayType { get; }
        [JsonPropertyName("plugItemHash")]
        public uint PlugItemHash { get; }

        public DestinyInsertPlugsRequestEntry(int socketIndex, DestinySocketArrayType socketArrayType,
            uint plugItemHash)
        {
            SocketIndex = socketIndex;
            SocketArrayType = socketArrayType;
            PlugItemHash = plugItemHash;
        }
    }
}