using System.Diagnostics;
using System.Threading.Tasks;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Models.Destiny;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBungieAPI.Models;

/// <summary>
///     Class that points to a certain definition in database
/// </summary>
/// <typeparam name="TDefinition">Destiny definition type</typeparam>
[DebuggerDisplay("{DebuggerDisplay}")]
public class DefinitionHashPointer<TDefinition> :
    IDeepEquatable<DefinitionHashPointer<TDefinition>>,
    IEquatable<DefinitionHashPointer<TDefinition>> where TDefinition : IDestinyDefinition
{
    /// <summary>
    ///     <inheritdoc>
    ///         <cref>IEquatable{T}.Equals</cref>
    ///     </inheritdoc>
    /// </summary>
    /// <param name="other">
    ///     <inheritdoc>
    ///         <cref>IEquatable{T}.Equals</cref>
    ///     </inheritdoc>
    /// </param>
    /// <returns></returns>
    public bool Equals(DefinitionHashPointer<TDefinition> other)
    {
        return other is not null &&
               Hash == other.Hash;
    }

    /// <summary>
    ///     <inheritdoc>
    ///         <cref>object.Equals</cref>
    ///     </inheritdoc>
    /// </summary>
    /// <param name="obj">
    ///     <inheritdoc>
    ///         <cref>object.Equals</cref>
    ///     </inheritdoc>
    /// </param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        return obj is DefinitionHashPointer<TDefinition> objPointer &&
               Equals(objPointer);
    }

    /// <summary>
    ///     <inheritdoc cref="object.GetHashCode" />
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
    public static DefinitionsEnum EnumValue { get; } = Enum.Parse<DefinitionsEnum>(typeof(TDefinition).Name);

    /// <summary>
    ///     Empty pointer
    /// </summary>
    public static DefinitionHashPointer<TDefinition> Empty { get; } = new(null);

    private bool _isMapped;
    private TDefinition _value;

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
    ///     Default constructor
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
    public bool TryGetDefinition(out TDefinition definition)
    {
        return TryGetDefinitionFromOtherLocale(Locale, out definition);
    }

    /// <summary>
    ///     Tries to get definition from local cache/given provider with specified locale
    /// </summary>
    /// <param name="locale"></param>
    /// <param name="definition"></param>
    /// <returns></returns>
    public bool TryGetDefinitionFromOtherLocale(BungieLocales locale, out TDefinition definition)
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
    ///     Returns a value if could be fetched or null if none was found
    /// </summary>
    /// <returns></returns>
    public TDefinition GetValueOrNull()
    {
        return TryGetDefinition(out var definition) ? definition : default(TDefinition);
    }

    /// <summary>
    ///     Returns a value from other locale if could be fetched or null if none was found
    /// </summary>
    /// <param name="locale"></param>
    /// <returns></returns>
    public TDefinition GetValueOrNullFromOtherLocale(BungieLocales locale)
    {
        return TryGetDefinitionFromOtherLocale(locale, out var definition) ? definition : default(TDefinition);
    }

    /// <summary>
    ///     Returns a value async if could be fetched or null if none was found
    /// </summary>
    /// <returns></returns>
    public async ValueTask<TDefinition> GetValueOrNullAsync()
    {
        TDefinition definition = default;
        if (HasValidHash)
            await _client.TryGetDefinitionAsync<TDefinition>(Hash.Value, Locale, def => definition = def);
        return definition;
    }

    /// <summary>
    ///     Returns a value from other locale async if could be fetched or null if none was found
    /// </summary>
    /// <param name="locale"></param>
    /// <returns></returns>
    public async ValueTask<TDefinition> GetValueOrNullFromOtherLocaleAsync(BungieLocales locale)
    {
        TDefinition definition = default;
        if (HasValidHash)
            await _client.TryGetDefinitionAsync<TDefinition>(Hash.Value, locale, def => definition = def);
        return definition;
    }

    /// <summary>
    ///     Tries to map value from repository
    /// </summary>
    public void TryMapValue()
    {
        if (_value is not null && _isMapped)
            return;
        if (!HasValidHash)
            return;
        if (!_client.TryGetDefinition<TDefinition>(
                Hash!.Value,
                Locale,
                out var definition))
            return;

        _value = definition;
        _isMapped = true;
    }

    /// <summary>
    ///     Gets underlying definition and checks whether this expression is True or False
    /// </summary>
    /// <param name="predicate">Condition to check for</param>
    /// <returns></returns>
    public bool Is(Func<TDefinition, bool> predicate)
    {
        if (_isMapped)
            return predicate(_value);
        return TryGetDefinition(out var definition) && predicate(definition);
    }

    /// <summary>
    ///     Tries to execute expression and get value, returns null if nothing was found
    /// </summary>
    /// <param name="func">Method to execute</param>
    /// <typeparam name="TValue">Return Type</typeparam>
    /// <returns></returns>
    public TValue Select<TValue>(Func<TDefinition, TValue> func)
    {
        if (_isMapped)
            return func(_value);
        return TryGetDefinition(out var definition) ? func(definition) : default(TValue);
    }

    /// <summary>
    ///     <inheritdoc cref="IDeepEquatable{T}.DeepEquals" />
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool DeepEquals(DefinitionHashPointer<TDefinition> other)
    {
        return Hash == other.Hash &&
               DefinitionEnumType == other.DefinitionEnumType &&
               Locale == other.Locale;
    }

    /// <summary>
    ///     Overload for quick hash comparing
    /// </summary>
    /// <param name="a"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public static bool operator ==(DefinitionHashPointer<TDefinition> a, uint hash)
    {
        return a is not null && a.Hash == hash;
    }

    /// <summary>
    ///     Overload for quick hash comparing
    /// </summary>
    /// <param name="a"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public static bool operator !=(DefinitionHashPointer<TDefinition> a, uint hash)
    {
        return !(a == hash);
    }

    /// <summary>
    ///     Constructs <see cref="DefinitionHashPointer{T}"/> from hash
    /// </summary>
    /// <param name="hash">Definition hash</param>
    /// <returns></returns>
    public static implicit operator DefinitionHashPointer<TDefinition>(uint hash)
    {
        return new DefinitionHashPointer<TDefinition>(hash);
    }

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