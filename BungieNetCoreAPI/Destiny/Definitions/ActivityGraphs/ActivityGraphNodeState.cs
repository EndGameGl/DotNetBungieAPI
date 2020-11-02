using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphNodeState
    {
        public int State { get; }

        [JsonConstructor]
        private ActivityGraphNodeState(int state)
        {
            State = state;
        }
    }
}
