using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI
{
    internal static class Defaults
    {
        internal static ReadOnlyCollection<T> EmptyReadOnlyCollection<T>() => new(Array.Empty<T>());
        internal static ReadOnlyDictionary<T, P> EmptyReadOnlyDictionary<T, P>() => new(new Dictionary<T, P>(0));
    }
}
