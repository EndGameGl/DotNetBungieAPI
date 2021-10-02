using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DotNetBungieAPI
{
    internal static class Defaults
    {
        internal static ReadOnlyCollection<T> EmptyReadOnlyCollection<T>()
        {
            return new ReadOnlyCollection<T>(Array.Empty<T>());
        }

        internal static ReadOnlyDictionary<T, TValue> EmptyReadOnlyDictionary<T, TValue>()
        {
            return new ReadOnlyDictionary<T, TValue>(new Dictionary<T, TValue>(0));
        }
    }
}