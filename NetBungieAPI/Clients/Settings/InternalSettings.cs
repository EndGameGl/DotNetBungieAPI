using NetBungieAPI.Logging;

namespace NetBungieAPI.Clients.Settings
{
    internal class InternalSettings
    {
        public bool IsLoggingEnabled { get; internal set; }
        public LogListener.NewMessageEvent OnLog { get; internal set; }

        public static InternalSettings Default => new()
        {
            IsLoggingEnabled = false
        };
    }
}