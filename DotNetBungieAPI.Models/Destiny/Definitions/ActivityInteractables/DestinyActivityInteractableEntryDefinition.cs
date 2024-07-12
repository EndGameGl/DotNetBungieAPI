using DotNetBungieAPI.Models.Destiny.Definitions.Activities;

namespace DotNetBungieAPI.Models.Destiny.Definitions.ActivityInteractables;

/// <summary>
///     Defines a specific interactable and the action that can occur when triggered.
/// </summary>
public sealed record DestinyActivityInteractableEntryDefinition
{
    /// <summary>
    ///     The activity that will trigger when you interact with this interactable.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;
}
