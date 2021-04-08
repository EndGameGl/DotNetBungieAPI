using NetBungieAPI.Models;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyHistoricalStatsActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> ActivityReference { get; init; }
        public DefinitionHashPointer<DestinyActivityDefinition> DirectorActivity { get; init; }
        public long InstanceId { get; init; }
        public DestinyActivityModeType Mode { get; init; }
        public ReadOnlyCollection<DestinyActivityModeType> Modes { get; init; }
        public bool IsPrivate { get; init; }
        public BungieMembershipType MembershipType { get; init; }

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
