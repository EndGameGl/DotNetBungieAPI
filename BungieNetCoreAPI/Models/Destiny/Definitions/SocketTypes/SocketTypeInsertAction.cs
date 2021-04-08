using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.SocketTypes
{
    public class SocketTypeInsertAction : IDeepEquatable<SocketTypeInsertAction>
    {
        public int ActionExecuteSeconds { get; init; }
        public int ActionSoundHash { get; init; }
        public SocketActionType ActionType { get; init; }
        public bool IsPositiveAction { get; init; }

        [JsonConstructor]
        internal SocketTypeInsertAction(int actionExecuteSeconds, int actionSoundHash, SocketActionType actionType, bool isPositiveAction)
        {
            ActionExecuteSeconds = actionExecuteSeconds;
            ActionSoundHash = actionSoundHash;
            ActionType = actionType;
            IsPositiveAction = isPositiveAction;
        }

        public bool DeepEquals(SocketTypeInsertAction other)
        {
            return other != null &&
                   ActionExecuteSeconds == other.ActionExecuteSeconds &&
                   ActionSoundHash == other.ActionSoundHash &&
                   ActionType == other.ActionType &&
                   IsPositiveAction == other.IsPositiveAction;
        }
    }
}
