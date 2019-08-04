using Newtonsoft.Json;
using System;

namespace Entities.Converters
{
    /// <summary>
    /// GuidConverter class is creating and coverting string representain of Guid.
    /// </summary>
    public class GuidConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Guid);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
                throw new Exception($"Unexpected token parsing Guid. Expected String, got {reader.TokenType}.");

            string value = reader.Value.ToString();

            if (string.IsNullOrWhiteSpace(value))
                return Guid.NewGuid().ToString();
            else
                return value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!string.IsNullOrWhiteSpace(value.ToString()))
            {
                writer.WriteValue(value.ToString());
            }
            else
            {
                throw new Exception("Expected string representation of Guid value.");
            }
        }
    }
}
