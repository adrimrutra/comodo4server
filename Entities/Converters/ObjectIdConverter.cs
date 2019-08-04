using MongoDB.Bson;
using Newtonsoft.Json;
using System;

namespace Entities.Converters
{
    /// <summary>
    /// ObjectIdConverter class is creating and coverting string representain of ObjectId.
    /// </summary>
    public class ObjectIdConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ObjectId);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!JsonToken.String.Equals(reader.TokenType))
                throw new Exception($"Unexpected token parsing ObjectId. Expected String, got {reader.TokenType}.");

            string value = reader.Value.ToString(); 

            if (string.IsNullOrWhiteSpace(value))
                return ObjectId.GenerateNewId().ToString();
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
                throw new Exception("Expected string representation of ObjectId value.");
            }
        }
    }
}
