using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.SocketTypes
{
    public class SocketTypeInsertAction : IDeepEquatable<SocketTypeInsertAction>
    {
        public int ActionExecuteSeconds { get; }
        public int ActionSoundHash { get; }
        public SocketActionType ActionType { get; }
        public bool IsPositiveAction { get; }

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
