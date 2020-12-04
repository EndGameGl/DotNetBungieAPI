using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SocketTypes
{
    public class SocketTypeInsertAction
    {
        public int ActionExecuteSeconds { get; }
        public int ActionSoundHash { get; }
        public SocketActionType ActionType { get; }
        public bool IsPositiveAction { get; }

        [JsonConstructor]
        private SocketTypeInsertAction(int actionExecuteSeconds, int actionSoundHash, SocketActionType actionType, bool isPositiveAction)
        {
            ActionExecuteSeconds = actionExecuteSeconds;
            ActionSoundHash = actionSoundHash;
            ActionType = actionType;
            IsPositiveAction = isPositiveAction;
        }
    }
}
