﻿namespace DotNetBungieAPI.Models.Destiny.Definitions.ActivityGraphs;

/// <summary>
///     This describes links between the current graph and others, as well as when that link is relevant.
/// </summary>
public sealed record DestinyLinkedGraphDefinition : IDeepEquatable<DestinyLinkedGraphDefinition>
{
    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("overview")]
    public string Overview { get; init; }

    [JsonPropertyName("linkedGraphId")]
    public uint LinkedGraphId { get; init; }

    [JsonPropertyName("unlockExpression")]
    public DestinyUnlockExpressionDefinition UnlockExpression { get; init; }

    [JsonPropertyName("linkedGraphs")]
    public ReadOnlyCollection<DestinyLinkedGraphEntryDefinition> LinkedGraphs { get; init; } =
        ReadOnlyCollection<DestinyLinkedGraphEntryDefinition>.Empty;

    public bool DeepEquals(DestinyLinkedGraphDefinition other)
    {
        return other != null
            && Description == other.Description
            && Name == other.Name
            && Overview == other.Overview
            && LinkedGraphId == other.LinkedGraphId
            && UnlockExpression.DeepEquals(other.UnlockExpression)
            && LinkedGraphs.DeepEqualsReadOnlyCollection(other.LinkedGraphs);
    }
}
