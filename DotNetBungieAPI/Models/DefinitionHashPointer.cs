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
public readonly struct DefinitionHashPointer<TDefinition> :
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
        return Hash == other.Hash;
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
        private TDefinition DebugValueGetter
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
    private static readonly IBungieClient Client = ServiceProviderInstance.Instance.GetService<IBungieClient>();

    /// <summary>
    ///     Definition enum value
    /// </summary>
    public static DefinitionsEnum EnumValue { get; } = Enum.Parse<DefinitionsEnum>(typeof(TDefinition).Name);

    /// <summary>
    ///     Empty pointer
    /// </summary>
    public static DefinitionHashPointer<TDefinition> Empty { get; } = new(null);

    /// <summary>
    ///     Definition hash, guaranteed to be unique across it's type.
    /// </summary>
    public uint? Hash { get; }

    /// <summary>
    ///     Definition type enum value
    /// </summary>
    public DefinitionsEnum DefinitionEnumType => EnumValue;

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
        Hash = hash;
    }

    /// <summary>
    ///     Default constructor
    /// </summary>
    /// <param name="hash"></param>
    public DefinitionHashPointer(uint hash)
    {
        Hash = hash;
    }

    /// <summary>
    ///     Tries to get definition from local cache/given provider
    /// </summary>
    /// <param name="definition">Found definition</param>
    /// <param name="locale"></param>
    /// <returns>True, if found, False otherwise</returns>
    public bool TryGetDefinition(out TDefinition definition, BungieLocales locale = BungieLocales.EN)
    {
        definition = default;
        return HasValidHash && Client.TryGetDefinition(Hash!.Value, locale, out definition);
    }

    /// <summary>
    ///     Returns a value if could be fetched or null if none was found
    /// </summary>
    /// <returns></returns>
    public TDefinition GetValueOrNull(
        BungieLocales locale = BungieLocales.EN)
    {
        return TryGetDefinition(out var definition, locale) ? definition : default;
    }

    /// <summary>
    ///     Returns a value async if could be fetched or null if none was found
    /// </summary>
    /// <returns></returns>
    public async ValueTask<TDefinition> GetValueOrNullAsync(
        BungieLocales locale = BungieLocales.EN)
    {
        TDefinition definition = default;
        
        if (HasValidHash)
            await Client.TryGetDefinitionAsync<TDefinition>(Hash.Value, locale, def => definition = def);
        return definition;
    }

    /// <summary>
    ///     Gets underlying definition and checks whether this expression is True or False
    /// </summary>
    /// <param name="predicate">Condition to check for</param>
    /// <param name="locale"></param>
    /// <returns></returns>
    public bool Is(
        Func<TDefinition, bool> predicate, 
        BungieLocales locale = BungieLocales.EN)
    {
        return TryGetDefinition(out var definition) && predicate(definition);
    }

    /// <summary>
    ///     Tries to execute expression and get value, returns null if nothing was found
    /// </summary>
    /// <param name="func">Method to execute</param>
    /// <param name="locale"></param>
    /// <typeparam name="TValue">Return Type</typeparam>
    /// <returns></returns>
    public TValue Select<TValue>(
        Func<TDefinition, TValue> func,
        BungieLocales locale = BungieLocales.EN)
    {
        return TryGetDefinition(out var definition) ? func(definition) : default;
    }

    /// <summary>
    ///     <inheritdoc cref="IDeepEquatable{T}.DeepEquals" />
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool DeepEquals(DefinitionHashPointer<TDefinition> other)
    {
        return Hash == other.Hash &&
               DefinitionEnumType == other.DefinitionEnumType;
    }

    /// <summary>
    ///     Overload for quick hash comparing
    /// </summary>
    /// <param name="a"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public static bool operator ==(DefinitionHashPointer<TDefinition> a, uint hash)
    {
        return a.Hash == hash;
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
    
    public static bool operator ==(DefinitionHashPointer<TDefinition> a, DefinitionHashPointer<TDefinition> b)
    {
        return a.Hash == b.Hash;
    }
    
    public static bool operator !=(DefinitionHashPointer<TDefinition> a, DefinitionHashPointer<TDefinition> b)
    {
        return !(a == b);
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

    private string DebuggerDisplay => GetDebuggerDisplayString();

    private string GetDebuggerDisplayString()
    {
        var value = HasValidHash
            ? $"{DefinitionEnumType} - {Hash}"
            : $"DefinitionHashPointer<{DefinitionEnumType}>.Empty";
        return value;
    }
}