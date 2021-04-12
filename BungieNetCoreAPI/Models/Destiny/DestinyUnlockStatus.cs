using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Unlocks;

namespace NetBungieAPI.Models.Destiny
{
    public sealed record DestinyUnlockStatus
    {
        [JsonPropertyName("unlockHash")]
        public DefinitionHashPointer<DestinyUnlockDefinition> Unlock { get; init; } =
            DefinitionHashPointer<DestinyUnlockDefinition>.Empty;

        [JsonPropertyName("isSet")] 
        public bool IsSet { get; init; }
    }
}