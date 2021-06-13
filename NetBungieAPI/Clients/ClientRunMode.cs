namespace NetBungieAPI.Clients
{
    /// <summary>
    /// Defines client work behaviour
    /// </summary>
    public enum ClientRunMode
    {
        /// <summary>
        /// Client will use OAuth2 mechanisms
        /// </summary>
        ClientSide,
        /// <summary>
        /// OAuth2 will be blocked (anyway it's only usable in browser apps)
        /// </summary>
        ServerSide,
        /// <summary>
        /// Client won't stop you from failing, do anything you want
        /// </summary>
        Any
    }
}
