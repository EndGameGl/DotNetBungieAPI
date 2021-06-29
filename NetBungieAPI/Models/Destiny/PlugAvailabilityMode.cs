namespace NetBungieAPI.Models.Destiny
{
    /// <summary>
    ///     This enum determines whether the plug is available to be inserted.
    /// </summary>
    public enum PlugAvailabilityMode
    {
        /// <summary>
        ///     Normal means that all existing rules for plug insertion apply.
        /// </summary>
        Normal = 0,

        /// <summary>
        ///     UnavailableIfSocketContainsMatchingPlugCategory means that the plug is only available if the socket does NOT match
        ///     the plug category.
        /// </summary>
        UnavailableIfSocketContainsMatchingPlugCategory = 1,

        /// <summary>
        ///     AvailableIfSocketContainsMatchingPlugCategory means that the plug is only available if the socket DOES match the
        ///     plug category.
        /// </summary>
        AvailableIfSocketContainsMatchingPlugCategory = 2
    }
}