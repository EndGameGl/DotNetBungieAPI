using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.SeasonPasses
{
    [DestinyDefinition(DefinitionsEnum.DestinySeasonPassDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinySeasonPassDefinition : IDestinyDefinition, IDeepEquatable<DestinySeasonPassDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> RewardProgression { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> PrestigeProgression { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinySeasonPassDefinition(uint rewardProgressionHash, uint prestigeProgressionHash, DestinyDefinitionDisplayProperties displayProperties,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            RewardProgression = new DefinitionHashPointer<DestinyProgressionDefinition>(rewardProgressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            PrestigeProgression = new DefinitionHashPointer<DestinyProgressionDefinition>(prestigeProgressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public void MapValues()
        {
            RewardProgression.TryMapValue();
            PrestigeProgression.TryMapValue();
        }
        public bool DeepEquals(DestinySeasonPassDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   RewardProgression.DeepEquals(other.RewardProgression) &&
                   PrestigeProgression.DeepEquals(other.PrestigeProgression) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
