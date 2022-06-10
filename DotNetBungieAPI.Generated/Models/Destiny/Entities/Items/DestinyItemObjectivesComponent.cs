namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

/// <summary>
///     Items can have objectives and progression. When you request this block, you will obtain information about any Objectives and progression tied to this item.
/// </summary>
public class DestinyItemObjectivesComponent
{
    /// <summary>
    ///     If the item has a hard association with objectives, your progress on them will be defined here. 
    /// <para />
    ///     Objectives are our standard way to describe a series of tasks that have to be completed for a reward.
    /// </summary>
    [JsonPropertyName("objectives")]
    public List<Destiny.Quests.DestinyObjectiveProgress> Objectives { get; set; }

    /// <summary>
    ///     I may regret naming it this way - but this represents when an item has an objective that doesn't serve a beneficial purpose, but rather is used for "flavor" or additional information. For instance, when Emblems track specific stats, those stats are represented as Objectives on the item.
    /// </summary>
    [JsonPropertyName("flavorObjective")]
    public object FlavorObjective { get; set; }

    /// <summary>
    ///     If we have any information on when these objectives were completed, this will be the date of that completion. This won't be on many items, but could be interesting for some items that do store this information.
    /// </summary>
    [JsonPropertyName("dateCompleted")]
    public DateTime DateCompleted { get; set; }
}
