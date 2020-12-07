using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Progressions
{
    public class ProgressionStep
    {
        public int DisplayEffectType { get; }
        public string Icon { get; }
        public int ProgressTotal { get; }
        public string StepName { get; }

        [JsonConstructor]
        private ProgressionStep(int displayEffectType, string icon, int progressTotal, string stepName)
        {
            DisplayEffectType = displayEffectType;
            Icon = icon;
            ProgressTotal = progressTotal;
            StepName = stepName;
        }
    }
}
