using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBungieAPI.Models.Requests
{
    public sealed class DestinyInsertPlugsFreeActionRequest
    {
        [JsonPropertyName("plug")]
        public DestinyInsertPlugsRequestEntry Plug { get; init; }

        [JsonPropertyName("itemId")]
        public long ItemId { get; init; }

        [JsonPropertyName("characterId")]
        public long CharacterId { get; init; }

        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; init; }
    }
}
