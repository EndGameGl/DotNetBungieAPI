namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     This enum determines whether the plug is available to be inserted.
/// <para />
///     - Normal means that all existing rules for plug insertion apply.
/// <para />
///     - UnavailableIfSocketContainsMatchingPlugCategory means that the plug is only available if the socket does NOT match the plug category.
/// <para />
///     - AvailableIfSocketContainsMatchingPlugCategory means that the plug is only available if the socket DOES match the plug category.
/// <para />
///     For category matching, use the plug's "plugCategoryIdentifier" property, comparing it to
/// </summary>
public enum PlugAvailabilityMode : int
{
    Normal = 0,

    UnavailableIfSocketContainsMatchingPlugCategory = 1,

    AvailableIfSocketContainsMatchingPlugCategory = 2
}
