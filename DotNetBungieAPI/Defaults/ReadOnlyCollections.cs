using System;
using System.Collections.ObjectModel;

namespace DotNetBungieAPI.Defaults
{
    internal class ReadOnlyCollections<T>
    {
        internal static ReadOnlyCollection<T> Empty { get; } = new ReadOnlyCollection<T>(Array.Empty<T>());
    }
}