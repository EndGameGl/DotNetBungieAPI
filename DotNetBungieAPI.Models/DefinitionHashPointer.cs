using System.Diagnostics;
using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Models;

/// <summary>
///     Class that points to a certain definition in database
/// </summary>
/// <typeparam name="TDefinition">Destiny definition type</typeparam>
#if DEBUG
[DebuggerDisplay("{DebuggerDisplay}")]
#endif
public readonly struct DefinitionHashPointer<TDefinition>
    : IDeepEquatable<DefinitionHashPointer<TDefinition>>,
        IEquatable<DefinitionHashPointer<TDefinition>>
    where TDefinition : IDestinyDefinition
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
    public override bool Equals(object? obj)
    {
        return obj is DefinitionHashPointer<TDefinition> objPointer && Equals(objPointer);
    }

    /// <summary>
    ///     <inheritdoc cref="object.GetHashCode" />
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return Hash.HasValue ? Hash.Value.ToInt32() : 0;
    }

    /// <summary>
    ///     Definition enum value
    /// </summary>
    public static DefinitionsEnum EnumValue { get; } =
        Enum.Parse<DefinitionsEnum>(typeof(TDefinition).Name);

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
    ///     <inheritdoc cref="IDeepEquatable{T}.DeepEquals" />
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool DeepEquals(DefinitionHashPointer<TDefinition> other)
    {
        return Hash == other.Hash && DefinitionEnumType == other.DefinitionEnumType;
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

    public static bool operator ==(
        DefinitionHashPointer<TDefinition> a,
        DefinitionHashPointer<TDefinition> b
    )
    {
        return a.Hash == b.Hash;
    }

    public static bool operator !=(
        DefinitionHashPointer<TDefinition> a,
        DefinitionHashPointer<TDefinition> b
    )
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

    private string DebuggerDisplay =>
        HasValidHash
            ? $"{DefinitionEnumType} - {Hash}"
            : $"DefinitionHashPointer<{DefinitionEnumType}>.Empty";
}
