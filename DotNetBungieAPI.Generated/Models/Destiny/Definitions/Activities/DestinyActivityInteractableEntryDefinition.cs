namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Activities;

/// <summary>
///     Defines a specific interactable and the action that can occur when triggered.
/// </summary>
public class DestinyActivityInteractableEntryDefinition
{
    /// <summary>
    ///     The activity that will trigger when you interact with this interactable.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }
}
