using System;

namespace NetBungieAPI.Bungie
{
    public class GlobalAlert
    {
        public string AlertKey { get; }
        public string AlertHtml { get; }
        public DateTime AlertTimestamp { get; }
        public string AlertLink { get; }
        public GlobalAlertLevel AlertLevel { get; }
        public GlobalAlertType AlertType { get; }
        public StreamInfo StreamInfo { get; }

        internal GlobalAlert(string AlertKey, string AlertHtml, DateTime AlertTimestamp, string AlertLink, GlobalAlertLevel AlertLevel, GlobalAlertType AlertType,
            StreamInfo StreamInfo)
        {
            this.AlertKey = AlertKey;
            this.AlertHtml = AlertHtml;
            this.AlertTimestamp = AlertTimestamp;
            this.AlertLink = AlertLink;
            this.AlertLevel = AlertLevel;
            this.AlertType = AlertType;
            this.StreamInfo = StreamInfo;
        }
    }
}
