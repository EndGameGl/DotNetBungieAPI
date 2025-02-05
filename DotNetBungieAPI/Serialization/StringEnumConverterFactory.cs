using System.Reflection;
using System.Runtime.CompilerServices;

namespace DotNetBungieAPI.Serialization;

public class StringEnumConverterFactory : JsonConverterFactory
{
    private readonly Type _enumTypeBase = typeof(Enum);

    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.BaseType == _enumTypeBase;
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converter = (JsonConverter)
            Activator.CreateInstance(
                type: typeof(StringEnumJsonConverter<>).MakeGenericType(typeToConvert),
                bindingAttr: BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: [typeToConvert],
                culture: null
            )!;

        return converter;
    }

    private class StringEnumJsonConverter<TEnum> : JsonConverter<TEnum>
        where TEnum : unmanaged, Enum
    {
        private readonly TypeCode _underlyingTypeCode;

        public StringEnumJsonConverter(Type enumType)
        {
            var underlyingType = enumType.GetField("value__")!.FieldType;
            _underlyingTypeCode = Type.GetTypeCode(underlyingType);
        }

        public override TEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    var stringValue = reader.GetString();
                    if (!char.IsDigit(stringValue![0]))
                        return (TEnum)Enum.Parse(typeToConvert, stringValue);

                    return _underlyingTypeCode switch
                    {
                        TypeCode.Byte => ConvertToEnum<TEnum, byte>(stringValue),
                        TypeCode.SByte => ConvertToEnum<TEnum, sbyte>(stringValue),
                        TypeCode.Int16 => ConvertToEnum<TEnum, short>(stringValue),
                        TypeCode.Int32 => ConvertToEnum<TEnum, int>(stringValue),
                        TypeCode.Int64 => ConvertToEnum<TEnum, long>(stringValue),
                        TypeCode.UInt16 => ConvertToEnum<TEnum, ushort>(stringValue),
                        TypeCode.UInt32 => ConvertToEnum<TEnum, uint>(stringValue),
                        TypeCode.UInt64 => ConvertToEnum<TEnum, ulong>(stringValue),
                        _ => throw new ArgumentOutOfRangeException(nameof(stringValue))
                    };
                default:
                    return _underlyingTypeCode switch
                    {
                        TypeCode.Byte => ConvertToEnum<TEnum, byte>(reader.GetByte()),
                        TypeCode.SByte => ConvertToEnum<TEnum, sbyte>(reader.GetSByte()),
                        TypeCode.Int16 => ConvertToEnum<TEnum, short>(reader.GetInt16()),
                        TypeCode.Int32 => ConvertToEnum<TEnum, int>(reader.GetInt32()),
                        TypeCode.Int64 => ConvertToEnum<TEnum, long>(reader.GetInt64()),
                        TypeCode.UInt16 => ConvertToEnum<TEnum, ushort>(reader.GetUInt16()),
                        TypeCode.UInt32 => ConvertToEnum<TEnum, uint>(reader.GetUInt32()),
                        TypeCode.UInt64 => ConvertToEnum<TEnum, ulong>(reader.GetUInt64()),
                        _ => throw new ArgumentOutOfRangeException(nameof(stringValue))
                    };
            }
        }

        public override void Write(
            Utf8JsonWriter writer,
            TEnum value,
            JsonSerializerOptions options
        )
        {
            switch (_underlyingTypeCode)
            {
                case TypeCode.Int32:
                    writer.WriteNumberValue(Unsafe.As<TEnum, int>(ref value));
                    break;
                case TypeCode.UInt32:
                    writer.WriteNumberValue(Unsafe.As<TEnum, uint>(ref value));
                    break;
                case TypeCode.UInt64:
                    writer.WriteNumberValue(Unsafe.As<TEnum, ulong>(ref value));
                    break;
                case TypeCode.Int64:
                    writer.WriteNumberValue(Unsafe.As<TEnum, long>(ref value));
                    break;
                case TypeCode.Int16:
                    writer.WriteNumberValue(Unsafe.As<TEnum, short>(ref value));
                    break;
                case TypeCode.UInt16:
                    writer.WriteNumberValue(Unsafe.As<TEnum, ushort>(ref value));
                    break;
                case TypeCode.Byte:
                    writer.WriteNumberValue(Unsafe.As<TEnum, byte>(ref value));
                    break;
                case TypeCode.SByte:
                    writer.WriteNumberValue(Unsafe.As<TEnum, sbyte>(ref value));
                    break;
            }
        }
    }

    private static TEnum ConvertToEnum<TEnum, TSource>(string sourceValue)
        where TSource : unmanaged, IParsable<TSource>
        where TEnum : unmanaged, Enum
    {
        var value = TSource.Parse(sourceValue, provider: null);
        return ConvertToEnum<TEnum, TSource>(value);
    }

    private static TEnum ConvertToEnum<TEnum, TSource>(TSource value)
        where TSource : unmanaged, IParsable<TSource>
        where TEnum : unmanaged, Enum
    {
        unsafe
        {
            if (sizeof(TEnum) > sizeof(TSource))
            {
                TEnum o = default;
                *(TSource*)&o = value;
                return o;
            }

            return *(TEnum*)&value;
        }
    }
}
