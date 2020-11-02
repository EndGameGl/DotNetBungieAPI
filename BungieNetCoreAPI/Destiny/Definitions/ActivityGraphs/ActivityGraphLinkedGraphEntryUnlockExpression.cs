using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphLinkedGraphEntryUnlockExpression
    {
        public int Scope { get; }

        [JsonConstructor]
        private ActivityGraphLinkedGraphEntryUnlockExpression(int scope)
        {
            Scope = scope;
        }
    }
}
