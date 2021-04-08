using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.SocketTypes
{
    public sealed record DestinyInsertPlugActionDefinition : IDeepEquatable<DestinyInsertPlugActionDefinition>
    {
        [JsonPropertyName("actionExecuteSeconds")]
        public int ActionExecuteSeconds { get; init; }
        [JsonPropertyName("actionSoundHash")]
        public int ActionSoundHash { get; init; }
        [JsonPropertyName("actionType")]
        public SocketTypeActionType ActionType { get; init; }
        [JsonPropertyName("isPositiveAction")]
        public bool IsPositiveAction { get; init; }

        public bool DeepEquals(DestinyInsertPlugActionDefinition other)
        {
            return other != null &&
                   ActionExecuteSeconds == other.ActionExecuteSeconds &&
                   ActionSoundHash == other.ActionSoundHash &&
                   ActionType == other.ActionType &&
                   IsPositiveAction == other.IsPositiveAction;
        }
    }
}
