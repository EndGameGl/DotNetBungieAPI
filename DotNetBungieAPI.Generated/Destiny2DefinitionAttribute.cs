using DotNetBungieAPI.Generated.Models;

namespace DotNetBungieAPI.Generated;

[AttributeUsage(AttributeTargets.Property)]
public class Destiny2DefinitionAttribute : Attribute
{
    public string Definition { get; private set; }
    public Type DefinitionType { get; private set; }

    public Destiny2DefinitionAttribute(string definition, Type type)
    {
        Definition = definition;
        DefinitionType = type;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class Destiny2DefinitionAttribute<TDefinition> : Destiny2DefinitionAttribute
    where TDefinition : IDestinyDefinition
{
    public string Definition { get; }
    public Type DefinitionType { get; }

    public Destiny2DefinitionAttribute(string definition)
        : base(definition, typeof(TDefinition)) { }
}
