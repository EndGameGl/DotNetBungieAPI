using BungieNetCoreAPI.Destiny.Profile.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Profile
{
    public class DestinyProfileComponent<T> : IProfileComponent
    {
        public T Data { get; }
        public ComponentPrivacy Privacy { get; }

        [JsonConstructor]
        private DestinyProfileComponent(T data, ComponentPrivacy privacy)
        {
            Data = data;
            Privacy = privacy;
        }
    }
}
