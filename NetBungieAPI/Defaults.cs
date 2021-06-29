using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI
{
    internal static class Defaults
    {
        internal static ReadOnlyCollection<T> EmptyReadOnlyCollection<T>()
        {
            return new(Array.Empty<T>());
        }

        internal static ReadOnlyDictionary<T, TValue> EmptyReadOnlyDictionary<T, TValue>()
        {
            return new(new Dictionary<T, TValue>(0));
        }
    }
}