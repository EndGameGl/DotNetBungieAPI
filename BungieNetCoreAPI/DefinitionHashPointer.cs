using NetBungieAPI.Destiny;
using NetBungieAPI.Destiny.Definitions;
using NetBungieAPI.Repositories;
using System;
using System.Threading.Tasks;
using NetBungieAPI.Services.ApiAccess.Interfaces;
using Newtonsoft.Json;

namespace NetBungieAPI
{
    /// <summary>
    /// Class that points to a certain definition in database
    /// </summary>
    /// <typeparam name="T">Destiny definition type</typeparam>
    public sealed record DefinitionHashPointer<T> : IDeepEquatable<DefinitionHashPointer<T>> where T : IDestinyDefinition
    {
#if DEBUG
        private T debug_value_getter
        {
            get
            {
                if (_repository.TryGetDestinyDefinition<T>(DefinitionEnumType, Hash.Value, Locale, out var def))
                    return def;
                else
                    throw new Exception("Definition is missing from repo.");
            }
        }
#endif

        private static readonly ILocalisedDestinyDefinitionRepositories _repository = StaticUnityContainer.GetDestinyDefinitionRepositories();

        public static DefinitionsEnum EnumValue { get; } = Enum.Parse<DefinitionsEnum>(typeof(T).Name);
        public static DefinitionHashPointer<T> Empty { get; } = new DefinitionHashPointer<T>(null, EnumValue);

        private bool _isMapped;
        private T _value;

        /// <summary>
        /// Definition hash, guaranteed to be unique across it's type.
        /// </summary>
        public uint? Hash { get; }
        /// <summary>
        /// Definition type enum value
        /// </summary>
        public DefinitionsEnum DefinitionEnumType => EnumValue;
        /// <summary>
        /// Definition locale
        /// </summary>
        public DestinyLocales Locale { get; }

        /// <summary>
        /// Whether this hash isn't empty.
        /// </summary>
        [JsonIgnore]
        public bool HasValidHash => Hash.HasValue && Hash.Value > 0;

        /// <summary>
        /// Class .ctor
        /// </summary>
        /// <param name="hash">Definition hash</param>
        /// <param name="type">Definition type</param>
        public DefinitionHashPointer(uint? hash, DefinitionsEnum type)
        {
            _value = default;
            _isMapped = false;
            Hash = hash;
            Locale = _repository.CurrentLocaleLoadContext;
        }
        public DefinitionHashPointer(uint? hash)
        {
            _value = default;
            _isMapped = false;
            Hash = hash;
            Locale = _repository.CurrentLocaleLoadContext;
        }
        /// <summary>
        /// Tries to get definition from local cache/API
        /// </summary>
        /// <param name="definition">Found definition</param>
        /// <returns>True, if found, False otherwise</returns>
        public bool TryGetDefinition(out T definition)
        {
            definition = default;
            if (_isMapped)
            {
                definition = _value;
                return true;
            }
            if (HasValidHash)
            {
                if (_repository.TryGetDestinyDefinition<T>(EnumValue, Hash.Value, Locale, out var foundDefinition))
                {
                    definition = foundDefinition;
                    return true;
                }
            }
            return false;
        }
        public async Task<DefinitionHashPointerDownloadResult<T>> TryDownloadDefinition()
        {
            if (HasValidHash)
            {
                var response = await StaticUnityContainer.GetService<IDestiny2MethodsAccess>().GetDestinyEntityDefinition<T>(DefinitionEnumType, Hash.Value);
                if (response.ErrorCode == PlatformErrorCodes.Success && response.Response != null)
                    return new DefinitionHashPointerDownloadResult<T>(response.Response, true);
                return new DefinitionHashPointerDownloadResult<T>(default, false, response.Message);
            }
            return new DefinitionHashPointerDownloadResult<T>(default, false, "Missing valid hash.");
        }
        public override string ToString()
        {
            return $"{(_isMapped ? _value.ToString() : $"{DefinitionEnumType} - {Hash} - {Locale}")}";
        }
        public void TryMapValue()
        {
            if (_value != null && _isMapped)
                return;
            if (HasValidHash)
            {
                if (_repository.TryGetDestinyDefinition<T>(DefinitionEnumType, Hash.Value, Locale, out var definition))
                {
                    _value = definition;
                    _isMapped = true;
                }
            }
        }
        public bool DeepEquals(DefinitionHashPointer<T> other)
        {
            return other != null &&
                   Hash == other.Hash &&
                   DefinitionEnumType == other.DefinitionEnumType &&
                   Locale == other.Locale;
        }
    }
}
