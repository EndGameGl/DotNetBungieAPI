using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardSheets
{
    /// <summary>
    /// Empty atm
    /// </summary>
    [DestinyDefinition(type: DefinitionsEnum.DestinyRewardSheetDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyRewardSheetDefinition : IDestinyDefinition
    {
        public uint SheetHash { get; }
        public int SheetIndex { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyRewardSheetDefinition(uint sheetHash, int sheetIndex,
            bool blacklisted, uint hash, int index, bool redacted)
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
    }
}
