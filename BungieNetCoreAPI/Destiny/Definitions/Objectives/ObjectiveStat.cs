using BungieNetCoreAPI.Destiny.Definitions.Stats;

namespace BungieNetCoreAPI.Destiny.Definitions.Objectives
{
    public class ObjectiveStat
    {
        public DefinitionHashPointer<DestinyStatDefinition> StatType { get; }
        public int Value { get; }
        public bool IsConditionallyActive { get; }

        private ObjectiveStat(uint statTypeHash, int value, bool isConditionallyActive)
        {
            StatType = new DefinitionHashPointer<DestinyStatDefinition>(statTypeHash, "DestinyStatDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            Value = value;
            IsConditionallyActive = isConditionallyActive;
        }
    }
}
