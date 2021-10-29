using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Models.Destiny;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBungieAPI.Models
{
    /// <summary>
    ///     Class that points to a certain definition in database
    /// </summary>
    /// <typeparam name="T">Destiny definition type</typeparam>
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class DefinitionHashPointer<T> :
        IDeepEquatable<DefinitionHashPointer<T>>,
        IEquatable<DefinitionHashPointer<T>> where T : IDestinyDefinition
    {
        /// <summary>
        /// <inheritdoc>
        ///     <cref>IEquatable{T}.Equals</cref>
        /// </inheritdoc>
        /// </summary>
        /// <param name="other">
        /// <inheritdoc>
        ///     <cref>IEquatable{T}.Equals</cref>
        /// </inheritdoc></param>
        /// <returns></returns>
        public bool Equals(DefinitionHashPointer<T> other)
        {
            return other is not null &&
                   Hash == other.Hash;
        }

        /// <summary>
        /// <inheritdoc>
        ///     <cref>object.Equals</cref>
        /// </inheritdoc>
        /// </summary>
        /// <param name="obj">
        /// <inheritdoc>
        ///     <cref>object.Equals</cref>
        /// </inheritdoc>
        /// </param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is DefinitionHashPointer<T> objPointer &&
                   Equals(objPointer);
        }

        /// <summary>
        /// <inheritdoc cref="object.GetHashCode"/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Hash.HasValue ? Hash.Value.ToInt32() : 0;
        }
#if DEBUG
        private T debug_value_getter
        {
            get
            {
                if (TryGetDefinition(out var def))
                {
                    return def;
                }

                throw new Exception("Failed to get definition");
            }
        }
#endif
        private static readonly IBungieClient _client = ServiceProviderInstance.Instance.GetService<IBungieClient>();

        /// <summary>
        ///     Definition enum value
        /// </summary>
        public static DefinitionsEnum EnumValue { get; } = Enum.Parse<DefinitionsEnum>(typeof(T).Name);

        /// <summary>
        ///     Empty pointer
        /// </summary>
        public static DefinitionHashPointer<T> Empty { get; } = new(null);

        private bool _isMapped;
        private T _value;

        /// <summary>
        ///     Definition hash, guaranteed to be unique across it's type.
        /// </summary>
        public uint? Hash { get; }

        /// <summary>
        ///     Definition type enum value
        /// </summary>
        public DefinitionsEnum DefinitionEnumType => EnumValue;

        /// <summary>
        ///     Definition locale
        /// </summary>
        public BungieLocales Locale { get; internal set; }

        /// <summary>
        ///     Whether this hash isn't empty.
        /// </summary>
        [JsonIgnore]
        public bool HasValidHash => Hash is > 0;

        /// <summary>
        ///     .ctor
        /// </summary>
        /// <param name="hash">Definition hash</param>
        internal DefinitionHashPointer(uint? hash)
        {
            _value = default;
            _isMapped = false;
            Hash = hash;
            Locale = BungieLocales.EN;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="locale"></param>
        public DefinitionHashPointer(uint hash, BungieLocales locale)
        {
            _value = default;
            _isMapped = false;
            Hash = hash;
            Locale = locale;
        }

        /// <summary>
        ///     Tries to get definition from local cache/given provider
        /// </summary>
        /// <param name="definition">Found definition</param>
        /// <returns>True, if found, False otherwise</returns>
        public bool TryGetDefinition(out T definition)
        {
            return TryGetDefinitionFromOtherLocale(Locale, out definition);
        }

        /// <summary>
        /// Tries to get definition from local cache/given provider with specified locale
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="definition"></param>
        /// <returns></returns>
        public bool TryGetDefinitionFromOtherLocale(BungieLocales locale, out T definition)
        {
            definition = default;
            if (_isMapped)
            {
                definition = _value;
                return true;
            }

            if (HasValidHash && _client.TryGetDefinition(Hash!.Value, locale, out definition))
            {
                _value = definition;
                _isMapped = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Tries to map value from repository
        /// </summary>
        public void TryMapValue()
        {
            if (_value is not null && _isMapped)
                return;
            if (!HasValidHash)
                return;
            if (!_client.TryGetDefinition<T>(
                Hash!.Value,
                Locale,
                out var definition))
                return;

            _value = definition;
            _isMapped = true;
        }

        /// <summary>
        /// <inheritdoc cref="IDeepEquatable{T}.DeepEquals"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool DeepEquals(DefinitionHashPointer<T> other)
        {
            return Hash == other.Hash &&
                   DefinitionEnumType == other.DefinitionEnumType &&
                   Locale == other.Locale;
        }

        /// <summary>
        /// Overload for quick hash comparing
        /// </summary>
        /// <param name="a"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool operator ==(DefinitionHashPointer<T> a, uint hash) => a is not null && a.Hash == hash;

        /// <summary>
        /// Overload for quick hash comparing
        /// </summary>
        /// <param name="a"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool operator !=(DefinitionHashPointer<T> a, uint hash) => !(a == hash);

        public static implicit operator DefinitionHashPointer<T>(uint hash)
            => new(hash);

        internal void SetLocale(BungieLocales locale)
        {
            Locale = locale;
        }

        private string DebuggerDisplay => GetDebuggerDisplayString();

        private string GetDebuggerDisplayString()
        {
            var value = HasValidHash
                ? $"{(_isMapped ? _value.ToString() : $"{DefinitionEnumType} - {Hash} - {Locale}")}"
                : $"DefinitionHashPointer<{DefinitionEnumType}>.Empty";
            return value;
        }
    }
}