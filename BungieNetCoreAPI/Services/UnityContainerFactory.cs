using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace BungieNetCoreAPI.Services
{
    internal static class UnityContainerFactory
    {
        internal static IUnityContainer Container;
        static UnityContainerFactory()
        {
            Container = new UnityContainer();
        }
    }
}
