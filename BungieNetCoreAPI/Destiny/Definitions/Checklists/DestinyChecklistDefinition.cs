using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Checklists
{
    /// <summary>
    /// By public demand, Checklists are loose sets of "things to do/things you have done" in Destiny that we were actually able to track. They include easter eggs you find in the world, unique chests you unlock, and other such data where the first time you do it is significant enough to be tracked, and you have the potential to "get them all".
    /// <para/>
    /// These may be account-wide, or may be per character.The status of these will be returned in related "Checklist" data coming down from API requests such as GetProfile or GetCharacter.
    /// <para/>
    ///  Generally speaking, the items in a checklist can be completed in any order: we return an ordered list which only implies the way we are showing them in our own UI, and you can feel free to alter it as you wish.
    /// <para/>
    /// Note that, in the future, there will be something resembling the old D1 Record Books in at least some vague form.When that is created, it may be that it will supercede much or all of this Checklist data. It remains to be seen if that will be the case, so for now assume that the Checklists will still exist even after the release of D2: Forsaken.
    /// </summary>
    [DestinyDefinition(type: DefinitionsEnum.DestinyChecklistDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyChecklistDefinition : IDestinyDefinition, IDeepEquatable<DestinyChecklistDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// The individual checklist items.
        /// </summary>
        public ReadOnlyCollection<ChecklistEntry> Entries { get; }
        /// <summary>
        /// Indicates whether you will find this checklist on the Profile or Character components.
        /// </summary>
        public Scope Scope { get; }
        /// <summary>
        /// A localized string prompting you to view the checklist.
        /// </summary>
        public string ViewActionString { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyChecklistDefinition(DestinyDefinitionDisplayProperties displayProperties, ChecklistEntry[] entries, Scope scope, string viewActionString,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Entries = entries.AsReadOnlyOrEmpty();
            Scope = scope;
            ViewActionString = viewActionString;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyChecklistDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Entries.DeepEqualsReadOnlyCollections(other.Entries) &&
                   Scope == other.Scope &&
                   ViewActionString == other.ViewActionString &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            foreach (var entry in Entries)
            {
                entry.Activity.TryMapValue();
                entry.Destination.TryMapValue();
                entry.Item.TryMapValue();
                entry.Location.TryMapValue();
                entry.Vendor.TryMapValue();
            }
        }
    }
}
