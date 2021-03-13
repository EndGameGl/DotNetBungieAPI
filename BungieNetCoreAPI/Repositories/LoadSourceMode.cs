namespace NetBungieApi.Repositories
{
    /// <summary>
    /// Loading mode for definition files
    /// </summary>
    public enum LoadSourceMode
    {
        /// <summary>
        /// Loads from JSON files
        /// </summary>
        JSON,
        /// <summary>
        /// Loads from SQLite database
        /// </summary>
        SQLite
    }
}
