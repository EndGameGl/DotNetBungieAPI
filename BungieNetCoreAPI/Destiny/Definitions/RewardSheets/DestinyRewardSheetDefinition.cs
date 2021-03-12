using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardSheets
{
    /// <summary>
    /// Empty atm
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyRewardSheetDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyRewardSheetDefinition : IDestinyDefinition, IDeepEquatable<DestinyRewardSheetDefinition>
    {
        public uint SheetHash { get; }
        public int SheetIndex { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyRewardSheetDefinition(uint sheetHash, int sheetIndex, bool blacklisted, uint hash, int index, bool redacted)
        {
            SheetHash = sheetHash;
            SheetIndex = sheetIndex;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }

        public bool DeepEquals(DestinyRewardSheetDefinition other)
        {
            return other != null &&
                   SheetHash == other.SheetHash &&
                   SheetIndex == other.SheetIndex &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            return;
        }
    }
}
