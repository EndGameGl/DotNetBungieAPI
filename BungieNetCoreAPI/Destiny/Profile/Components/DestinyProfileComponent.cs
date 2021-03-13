using NetBungieApi.Destiny.Profile.Components;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Profile
{
    public class DestinyProfileComponent<T> : IProfileComponent
    {
        public T Data { get; internal set; }
        public ComponentPrivacy Privacy { get; }
        /// <summary>
        /// If true, this component is disabled.
        /// </summary>
        public bool? IsDisabled { get; }

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
