using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ItemTierTypes
{
    public class ItemTierTypeInfusionProcess
    {
        public double BaseQualityTransferRatio { get; }
        public int MinimumQualityIncrement { get; }

        [JsonConstructor]
        private ItemTierTypeInfusionProcess(double baseQualityTransferRatio, int minimumQualityIncrement)
        {
            BaseQualityTransferRatio = baseQualityTransferRatio;
            MinimumQualityIncrement = minimumQualityIncrement;
        }
    }
}
