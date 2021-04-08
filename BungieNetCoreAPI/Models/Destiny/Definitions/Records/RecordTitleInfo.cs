using NetBungieAPI.Destiny.Definitions.Genders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Records
{
    public class RecordTitleInfo : IDeepEquatable<RecordTitleInfo>
    {
        public bool HasTitle { get; init; }
        public ReadOnlyDictionary<DestinyGenderTypes, string> TitlesByGender { get; init; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> TitlesByGenderHash { get; init; }
        public DefinitionHashPointer<DestinyRecordDefinition> GildingTrackingRecord { get; init; }

        [JsonConstructor]
        internal RecordTitleInfo(bool hasTitle, Dictionary<DestinyGenderTypes, string> titlesByGender, Dictionary<uint, string> titlesByGenderHash,
            uint? gildingTrackingRecordHash)
        {
            HasTitle = hasTitle;
            TitlesByGender = titlesByGender.AsReadOnlyDictionaryOrEmpty();
            TitlesByGenderHash = titlesByGenderHash.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyGenderDefinition, string>(DefinitionsEnum.DestinyGenderDefinition);
            GildingTrackingRecord = new DefinitionHashPointer<DestinyRecordDefinition>(gildingTrackingRecordHash, DefinitionsEnum.DestinyRecordDefinition);
        }

        public bool DeepEquals(RecordTitleInfo other)
        {
            return other != null &&
                   HasTitle == other.HasTitle &&
                   TitlesByGender.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue(other.TitlesByGender) &&
                   TitlesByGenderHash.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.TitlesByGenderHash) &&
                   GildingTrackingRecord.DeepEquals(other.GildingTrackingRecord);
        }
    }
}
