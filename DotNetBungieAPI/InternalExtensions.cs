using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI
{
    internal static class InternalExtensions
    {
        internal static bool DeepEqualsReadOnlySimpleCollection<T>(this ReadOnlyCollection<T> compared,
            ReadOnlyCollection<T> comparedWith)
        {
            if (compared.Count != comparedWith.Count)
                return false;
            for (var i = 0; i < compared.Count; i++)
                if (!compared[i].Equals(comparedWith[i]))
                    return false;

            return true;
        }

        internal static bool DeepEqualsReadOnlyCollections<T>(this ReadOnlyCollection<T> compared,
            ReadOnlyCollection<T> comparedWith) where T : IDeepEquatable<T>
        {
            if (compared.Count != comparedWith.Count)
                return false;

            for (var i = 0; i < compared.Count; i++)
                if (!compared[i].DeepEquals(comparedWith[i]))
                    return false;

            return true;
        }

        internal static bool DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue<T, P>(
            this ReadOnlyDictionary<T, P> compared, ReadOnlyDictionary<T, P> comparedWith) where T : IDeepEquatable<T>
        {
            if (compared.Count != comparedWith.Count)
                return false;

            for (var i = 0; i < compared.Count; i++)
                if (!compared.ElementAt(i).Key.DeepEquals(comparedWith.ElementAt(i).Key) ||
                    !compared.ElementAt(i).Value.Equals(comparedWith.ElementAt(i).Value))
                    return false;
            return true;
        }

        internal static bool DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue<T, P>(
            this ReadOnlyDictionary<T, P> compared, ReadOnlyDictionary<T, P> comparedWith) where P : IDeepEquatable<P>
        {
            if (compared.Count != comparedWith.Count)
                return false;

            for (var i = 0; i < compared.Count; i++)
                if (!compared.ElementAt(i).Value.DeepEquals(comparedWith.ElementAt(i).Value) ||
                    !compared.ElementAt(i).Key.Equals(comparedWith.ElementAt(i).Key))
                    return false;
            return true;
        }

        internal static bool DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue<T, P>(
            this ReadOnlyDictionary<T, P> compared, ReadOnlyDictionary<T, P> comparedWith)
        {
            if (compared.Count != comparedWith.Count)
                return false;

            for (var i = 0; i < compared.Count; i++)
                if (!compared.ElementAt(i).Value.Equals(comparedWith.ElementAt(i).Value) ||
                    !compared.ElementAt(i).Key.Equals(comparedWith.ElementAt(i).Key))
                    return false;
            return true;
        }

        /// <summary>
        /// Converts destiny component types to query string
        /// </summary>
        /// <param name="componentTypes"></param>
        /// <returns></returns>
        internal static string ComponentsToWordString(this IEnumerable<DestinyComponentType> componentTypes)
        {
            return string.Join(',', componentTypes);
        }

        /// <summary>
        /// Converts destiny component types to query string
        /// </summary>
        /// <param name="componentTypes"></param>
        /// <returns></returns>
        internal static string ComponentsToIntString(this IEnumerable<DestinyComponentType> componentTypes)
        {
            return string.Join(',', componentTypes.Select(x => (int)x));
        }

        /// <summary>
        /// Converts <see cref="uint"/> hash to <see cref="int"/> value
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static int ToInt32(this uint hash)
        {
            return unchecked((int)hash);
        }

        /// <summary>
        /// Converts <see cref="int"/> hash to <see cref="uint"/> value
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static uint ToUInt32(this int hash)
        {
            return unchecked((uint)hash);
        }
    }
}