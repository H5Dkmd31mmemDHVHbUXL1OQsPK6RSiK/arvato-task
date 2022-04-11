using Arvato.Payment.Core.Helpers;
using Newtonsoft.Json;

namespace Arvato.Payment.Infrastrcute.JsonConverters;

public class NoWhiteSpaceStringConverter : JsonConverter
{
    public override bool CanRead => true;
    public override bool CanWrite => false;
    public override bool CanConvert(Type objectType) => objectType == typeof(string);

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        return StringHelpers.ReplaceWhitespace((string)reader.Value!);
    }
}