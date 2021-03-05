using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;

namespace BungieNetCoreAPI.Destiny.Definitions.Locations
{
    /// <summary>
    /// A "Location" is a sort of shortcut for referring to a specific combination of Activity, Destination, Place, and even Bubble or NavPoint within a space.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyLocationDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyLocationDefinition : IDestinyDefinition, IDeepEquatable<DestinyLocationDefinition>
    {
        /// <summary>
        /// A Location may refer to different specific spots in the world based on the world's current state. This is a list of those potential spots, and the data we can use at runtime to determine which one of the spots is the currently valid one.
        /// </summary>
        public ReadOnlyCollection<LocationRelease> LocationReleases { get; }
        /// <summary>
        /// If the location has a Vendor on it, this is the Vendor.
        /// </summary>
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyLocationDefinition(LocationRelease[] locationReleases, uint vendorHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            LocationReleases = locationReleases.AsReadOnlyOrEmpty();
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} ({LocationReleases.Count} location releases.) {LocationReleases.LastOrDefault()?.DisplayProperties.Name}";
        }

        public bool DeepEquals(DestinyLocationDefinition other)
        {
            return other != null &&
                   LocationReleases.DeepEqualsReadOnlyCollections(other.LocationReleases) &&
                   Vendor.DeepEquals(other.Vendor) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            Vendor.TryMapValue();
            foreach (var locationRelease in LocationReleases)
            {
                locationRelease.Activity.TryMapValue();
                locationRelease.ActivityGraph.TryMapValue();
                locationRelease.Destination.TryMapValue();
            }
        }
    }
}
