using NetBungieApi.Destiny.Definitions.Genders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.Records
{
    public class RecordTitleInfo : IDeepEquatable<RecordTitleInfo>
    {
        public bool HasTitle { get; }
        public ReadOnlyDictionary<DestinyGenderTypes, string> TitlesByGender { get; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyGenderDefinition>, string> TitlesByGenderHash { get; }
        public DefinitionHashPointer<DestinyRecordDefinition> GildingTrackingRecord { get; }

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
