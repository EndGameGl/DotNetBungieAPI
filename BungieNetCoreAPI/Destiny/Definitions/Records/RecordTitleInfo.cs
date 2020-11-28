using BungieNetCoreAPI.Destiny.Definitions.Genders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordTitleInfo
    {
        public bool HasTitle { get; }
        public Dictionary<DestinyGenderTypes, string> TitlesByGender { get; }
        public Dictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> TitlesByGenderHash { get; }

        [JsonConstructor]
        private RecordTitleInfo(bool hasTitle, Dictionary<DestinyGenderTypes, string> titlesByGender, Dictionary<uint, string> titlesByGenderHash)
        {
            HasTitle = hasTitle;
            TitlesByGender = titlesByGender;
            if (titlesByGenderHash != null)
            {
                TitlesByGenderHash = new Dictionary<DefinitionHashPointer<DestinyGenderDefinition>, string>();
                foreach (var titleByGenderHash in titlesByGenderHash)
                {
                    TitlesByGenderHash.Add(new DefinitionHashPointer<DestinyGenderDefinition>(titleByGenderHash.Key, "DestinyGenderDefinition"), titleByGenderHash.Value);
                }
            }
        }
    }
}
