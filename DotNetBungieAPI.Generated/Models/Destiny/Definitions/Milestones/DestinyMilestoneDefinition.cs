namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

/// <summary>
///     Milestones are an in-game concept where they're attempting to tell you what you can do next in-game.
/// <para />
///     If that sounds a lot like Advisors in Destiny 1, it is! So we threw out Advisors in the Destiny 2 API and tacked all of the data we would have put on Advisors onto Milestones instead.
/// <para />
///     Each Milestone represents something going on in the game right now:
/// <para />
///     - A "ritual activity" you can perform, like nightfall
/// <para />
///     - A "special event" that may have activities related to it, like Taco Tuesday (there's no Taco Tuesday in Destiny 2)
/// <para />
///     - A checklist you can fulfill, like helping your Clan complete all of its weekly objectives
/// <para />
///     - A tutorial quest you can play through, like the introduction to the Crucible.
/// <para />
///     Most of these milestones appear in game as well. Some of them are BNet only, because we're so extra. You're welcome.
/// <para />
///     There are some important caveats to understand about how we currently render Milestones and their deficiencies. The game currently doesn't have any content that actually tells you oughtright *what* the Milestone is: that is to say, what you'll be doing. The best we get is either a description of the overall Milestone, or of the Quest that the Milestone is having you partake in: which is usually something that assumes you already know what it's talking about, like "Complete 5 Challenges". 5 Challenges for what? What's a challenge? These are not questions that the Milestone data will answer for you unfortunately.
/// <para />
///     This isn't great, and in the future I'd like to add some custom text to give you more contextual information to pass on to your users. But for now, you can do what we do to render what little display info we do have:
/// <para />
///     Start by looking at the currently active quest (ideally, you've fetched DestinyMilestone or DestinyPublicMilestone data from the API, so you know the currently active quest for the Milestone in question). Look up the Quests property in the Milestone Definition, and check if it has display properties. If it does, show that as the description of the Milestone. If it doesn't, fall back on the Milestone's description.
/// <para />
///     This approach will let you avoid, whenever possible, the even less useful (and sometimes nonexistant) milestone-level names and descriptions.
/// </summary>
public class DestinyMilestoneDefinition : IDeepEquatable<DestinyMilestoneDefinition>
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     A hint to the UI to indicate what to show as the display properties for this Milestone when showing "Live" milestone data. Feel free to show more than this if desired: this hint is meant to simplify our own UI, but it may prove useful to you as well.
    /// </summary>
    [JsonPropertyName("displayPreference")]
    public Destiny.Definitions.Milestones.DestinyMilestoneDisplayPreference DisplayPreference { get; set; }

    /// <summary>
    ///     A custom image someone made just for the milestone. Isn't that special?
    /// </summary>
    [JsonPropertyName("image")]
    public string Image { get; set; }

    /// <summary>
    ///     An enumeration listing one of the possible types of milestones. Check out the DestinyMilestoneType enum for more info!
    /// </summary>
    [JsonPropertyName("milestoneType")]
    public Destiny.Definitions.Milestones.DestinyMilestoneType MilestoneType { get; set; }

    /// <summary>
    ///     If True, then the Milestone has been integrated with BNet's recruiting feature.
    /// </summary>
    [JsonPropertyName("recruitable")]
    public bool Recruitable { get; set; }

    /// <summary>
    ///     If the milestone has a friendly identifier for association with other features - such as Recruiting - that identifier can be found here. This is "friendly" in that it looks better in a URL than whatever the identifier for the Milestone actually is.
    /// </summary>
    [JsonPropertyName("friendlyName")]
    public string FriendlyName { get; set; }

    /// <summary>
    ///     If TRUE, this entry should be returned in the list of milestones for the "Explore Destiny" (i.e. new BNet homepage) features of Bungie.net (as long as the underlying event is active) Note that this is a property specifically used by BNet and the companion app for the "Live Events" feature of the front page/welcome view: it's not a reflection of what you see in-game.
    /// </summary>
    [JsonPropertyName("showInExplorer")]
    public bool ShowInExplorer { get; set; }

    /// <summary>
    ///     Determines whether we'll show this Milestone in the user's personal Milestones list.
    /// </summary>
    [JsonPropertyName("showInMilestones")]
    public bool ShowInMilestones { get; set; }

    /// <summary>
    ///     If TRUE, "Explore Destiny" (the front page of BNet and the companion app) prioritize using the activity image over any overriding Quest or Milestone image provided. This unfortunate hack is brought to you by Trials of The Nine.
    /// </summary>
    [JsonPropertyName("explorePrioritizesActivityImage")]
    public bool ExplorePrioritizesActivityImage { get; set; }

    /// <summary>
    ///     A shortcut for clients - and the server - to understand whether we can predict the start and end dates for this event. In practice, there are multiple ways that an event could have predictable date ranges, but not all events will be able to be predicted via any mechanism (for instance, events that are manually triggered on and off)
    /// </summary>
    [JsonPropertyName("hasPredictableDates")]
    public bool HasPredictableDates { get; set; }

    /// <summary>
    ///     The full set of possible Quests that give the overview of the Milestone event/activity in question. Only one of these can be active at a time for a given Conceptual Milestone, but many of them may be "available" for the user to choose from. (for instance, with Milestones you can choose from the three available Quests, but only one can be active at a time) Keyed by the quest item.
    /// <para />
    ///     As of Forsaken (~September 2018), Quest-style Milestones are being removed for many types of activities. There will likely be further revisions to the Milestone concept in the future.
    /// </summary>
    [JsonPropertyName("quests")]
    public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneQuestDefinition> Quests { get; set; }

    /// <summary>
    ///     If this milestone can provide rewards, this will define the categories into which the individual reward entries are placed.
    /// <para />
    ///     This is keyed by the Category's hash, which is only guaranteed to be unique within a given Milestone.
    /// </summary>
    [JsonPropertyName("rewards")]
    public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneRewardCategoryDefinition> Rewards { get; set; }

    /// <summary>
    ///     If you're going to show Vendors for the Milestone, you can use this as a localized "header" for the section where you show that vendor data. It'll provide a more context-relevant clue about what the vendor's role is in the Milestone.
    /// </summary>
    [JsonPropertyName("vendorsDisplayTitle")]
    public string VendorsDisplayTitle { get; set; }

    /// <summary>
    ///     Sometimes, milestones will have rewards provided by Vendors. This definition gives the information needed to understand which vendors are relevant, the order in which they should be returned if order matters, and the conditions under which the Vendor is relevant to the user.
    /// </summary>
    [JsonPropertyName("vendors")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneVendorDefinition> Vendors { get; set; }

    /// <summary>
    ///     Sometimes, milestones will have arbitrary values associated with them that are of interest to us or to third party developers. This is the collection of those values' definitions, keyed by the identifier of the value and providing useful definition information such as localizable names and descriptions for the value.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, Destiny.Definitions.Milestones.DestinyMilestoneValueDefinition> Values { get; set; }

    /// <summary>
    ///     Some milestones are explicit objectives that you can see and interact with in the game. Some milestones are more conceptual, built by BNet to help advise you on activities and events that happen in-game but that aren't explicitly shown in game as Milestones. If this is TRUE, you can see this as a milestone in the game. If this is FALSE, it's an event or activity you can participate in, but you won't see it as a Milestone in the game's UI.
    /// </summary>
    [JsonPropertyName("isInGameMilestone")]
    public bool IsInGameMilestone { get; set; }

    /// <summary>
    ///     A Milestone can now be represented by one or more activities directly (without a backing Quest), and that activity can have many challenges, modifiers, and related to it.
    /// </summary>
    [JsonPropertyName("activities")]
    public List<Destiny.Definitions.Milestones.DestinyMilestoneChallengeActivityDefinition> Activities { get; set; }

    [JsonPropertyName("defaultOrder")]
    public int DefaultOrder { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }

    public bool DeepEquals(DestinyMilestoneDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               DisplayPreference == other.DisplayPreference &&
               Image == other.Image &&
               MilestoneType == other.MilestoneType &&
               Recruitable == other.Recruitable &&
               FriendlyName == other.FriendlyName &&
               ShowInExplorer == other.ShowInExplorer &&
               ShowInMilestones == other.ShowInMilestones &&
               ExplorePrioritizesActivityImage == other.ExplorePrioritizesActivityImage &&
               HasPredictableDates == other.HasPredictableDates &&
               Quests.DeepEqualsDictionary(other.Quests) &&
               Rewards.DeepEqualsDictionary(other.Rewards) &&
               VendorsDisplayTitle == other.VendorsDisplayTitle &&
               Vendors.DeepEqualsList(other.Vendors) &&
               Values.DeepEqualsDictionary(other.Values) &&
               IsInGameMilestone == other.IsInGameMilestone &&
               Activities.DeepEqualsList(other.Activities) &&
               DefaultOrder == other.DefaultOrder &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }
}