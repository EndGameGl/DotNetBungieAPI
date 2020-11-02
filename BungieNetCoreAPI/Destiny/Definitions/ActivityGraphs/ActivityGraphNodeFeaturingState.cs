using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphNodeFeaturingState
    {
        public int HighlightType { get; }

        [JsonConstructor]
        private ActivityGraphNodeFeaturingState(int highlightType)
        {
            HighlightType = highlightType;
        }
    }
}
