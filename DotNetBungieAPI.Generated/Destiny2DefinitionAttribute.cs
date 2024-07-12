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
{
    public string Definition { get; private set; }
    public Type DefinitionType { get; private set; }

    public Destiny2DefinitionAttribute(string definition)
        : base(definition, typeof(TDefinition)) { }
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class Destiny2DefinitionListAttribute<TDefinition> : Destiny2DefinitionAttribute
{
    public string Definition { get; private set; }
    public Type DefinitionType { get; private set; }

    public Destiny2DefinitionListAttribute(string definition)
        : base(definition, typeof(TDefinition)) { }
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class Destiny2DefinitionDictionaryKeyAttribute<TDefinition>
    : Destiny2DefinitionAttribute
{
    public string Definition { get; private set; }
    public Type DefinitionType { get; private set; }

    public Destiny2DefinitionDictionaryKeyAttribute(string definition)
        : base(definition, typeof(TDefinition)) { }
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class Destiny2DefinitionDictionaryValueAttribute<TDefinition>
    : Destiny2DefinitionAttribute
{
    public string Definition { get; private set; }
    public Type DefinitionType { get; private set; }

    public Destiny2DefinitionDictionaryValueAttribute(string definition)
        : base(definition, typeof(TDefinition)) { }
}
