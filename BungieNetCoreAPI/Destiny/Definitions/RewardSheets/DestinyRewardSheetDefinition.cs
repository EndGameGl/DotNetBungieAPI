using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardSheets
{
    /// <summary>
    /// Empty atm
    /// </summary>
    [DestinyDefinition(name: "DestinyRewardSheetDefinition", presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyRewardSheetDefinition : DestinyDefinition
    {
        public uint SheetHash { get; }
        public int SheetIndex { get; }

        [JsonConstructor]
        private DestinyRewardSheetDefinition(uint sheetHash, int sheetIndex,
            bool blacklisted, uint hash, int index, bool redacted) : base(blacklisted, hash, index, redacted)
        {
            SheetHash = sheetHash;
            SheetIndex = sheetIndex;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
