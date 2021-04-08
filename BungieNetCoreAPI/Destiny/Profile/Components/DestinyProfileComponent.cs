using NetBungieAPI.Destiny.Profile.Components;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile
{
    public class DestinyProfileComponent<T> : IProfileComponent
    {
        public T Data { get; internal set; }
        public ComponentPrivacy Privacy { get; init; }
        /// <summary>
        /// If true, this component is disabled.
        /// </summary>
        public bool? IsDisabled { get; init; }

        [JsonConstructor]
        internal DestinyProfileComponent(T data, ComponentPrivacy privacy, bool? disabled)
        {
            Data = data;
            Privacy = privacy;
            IsDisabled = disabled;
        }
        internal DestinyProfileComponent() { }
    }
}
