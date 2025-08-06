namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

/// <summary>
///     Defines a specific interactable and the action that can occur when triggered.
/// </summary>
public sealed class DestinyActivityInteractableEntryDefinition
{
    /// <summary>
    ///     The activity that will trigger when you interact with this interactable.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition> ActivityHash { get; init; }
}
