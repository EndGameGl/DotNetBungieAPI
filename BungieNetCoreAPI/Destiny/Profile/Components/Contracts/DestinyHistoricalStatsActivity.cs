using NetBungieApi.Bungie;
using NetBungieApi.Destiny.Definitions.Activities;
using NetBungieApi.Destiny.Definitions.ActivityModes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalStatsActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> ActivityReference { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> DirectorActivity { get; }
        public long InstanceId { get; }
        public DestinyActivityModeType Mode { get; }
        public ReadOnlyCollection<DestinyActivityModeType> Modes { get; }
        public bool IsPrivate { get; }
        public BungieMembershipType MembershipType { get; }

        [JsonConstructor]
        internal DestinyHistoricalStatsActivity(uint referenceId, uint directorActivityHash, long instanceId, DestinyActivityModeType mode,
            DestinyActivityModeType[] modes, bool isPrivate, BungieMembershipType membershipType)
        {
            ActivityReference = new DefinitionHashPointer<DestinyActivityDefinition>(referenceId, DefinitionsEnum.DestinyActivityDefinition);
            DirectorActivity = new DefinitionHashPointer<DestinyActivityDefinition>(directorActivityHash, DefinitionsEnum.DestinyActivityDefinition);
            InstanceId = instanceId;
            Mode = mode;
            Modes = modes.AsReadOnlyOrEmpty();
            IsPrivate = isPrivate;
            MembershipType = membershipType;
        }
    }
}
