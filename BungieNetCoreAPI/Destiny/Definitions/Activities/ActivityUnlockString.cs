using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityUnlockString
    {
        public string DisplayString { get; }

        [JsonConstructor]
        private ActivityUnlockString(string displayString)
        {
            DisplayString = displayString;
        }
    }
}
