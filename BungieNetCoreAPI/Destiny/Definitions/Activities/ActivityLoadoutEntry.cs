using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.Activities
{
    public class ActivityLoadoutEntry : IDeepEquatable<ActivityLoadoutEntry>
    {
        /// <summary>
        /// The set of requirements that will be applied on the activity if this requirement set is active.
        /// </summary>
        public ReadOnlyCollection<ActivityLoadoutRequirement> Requirements { get; }

        internal ActivityLoadoutEntry(ActivityLoadoutRequirement[] requirements)
        {
            Requirements = requirements.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(ActivityLoadoutEntry other)
        {
            return other != null && Requirements.DeepEqualsReadOnlyCollections(other.Requirements);
        }
    }
}
