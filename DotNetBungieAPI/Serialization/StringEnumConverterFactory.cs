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
                typeof(StringEnumJsonConverter<>).MakeGenericType(typeToConvert),
                BindingFlags.Instance | BindingFlags.Public,
                null,
                new object[] { typeToConvert },
                null
            );

        return converter;
    }

    private class StringEnumJsonConverter<TEnum> : JsonConverter<TEnum>
        where TEnum : unmanaged, Enum
    {
        private readonly Type _enumType;
        private readonly Type _underlyingType;
        private readonly TypeCode _underlyingTypeCode;

        public StringEnumJsonConverter(Type enumType)
        {
            _enumType = enumType;
            _underlyingType = _enumType.GetField("value__")!.FieldType;
            _underlyingTypeCode = Type.GetTypeCode(_underlyingType);
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
                    if (!char.IsDigit(stringValue[0]))
                        return (TEnum)Enum.Parse(typeToConvert, stringValue);
                    return _underlyingTypeCode switch
                    {
                        TypeCode.Byte => ConvertToEnum<TEnum, byte>(byte.Parse(stringValue)),
                        TypeCode.SByte => ConvertToEnum<TEnum, sbyte>(sbyte.Parse(stringValue)),
                        TypeCode.Int16 => ConvertToEnum<TEnum, short>(short.Parse(stringValue)),
                        TypeCode.Int32 => ConvertToEnum<TEnum, int>(int.Parse(stringValue)),
                        TypeCode.Int64 => ConvertToEnum<TEnum, long>(long.Parse(stringValue)),
                        TypeCode.UInt16 => ConvertToEnum<TEnum, ushort>(ushort.Parse(stringValue)),
                        TypeCode.UInt32 => ConvertToEnum<TEnum, uint>(uint.Parse(stringValue)),
                        TypeCode.UInt64 => ConvertToEnum<TEnum, ulong>(ulong.Parse(stringValue)),
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

    public static TEnum ConvertToEnum<TEnum, TSource>(TSource value)
        where TSource : unmanaged
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
            else
            {
                return *(TEnum*)&value;
            }
        }
    }
}
