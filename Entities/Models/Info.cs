using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;
using Entities.Converters;

namespace Entities
{
    public class Info
    {
        [JsonConverter(typeof(ObjectIdConverter))]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("index")]
        public int Index { get; set; }
       
        [JsonConverter(typeof(ObjectIdConverter))]
        [BsonElement("guid")]
        public string Guid { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        [BsonElement("balance")]
        public string Balance { get; set; }

        [BsonElement("picture")]
        public string Picture { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("eyeColor")]
        public string EyeColor { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("company")]
        public string Company { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("about")]
        public string About { get; set; }

        [BsonElement("registered")]
        public string Registered { get; set; }

        [BsonElement("latitude")]
        public double Latitude { get; set; }

        [BsonElement("longitude")]
        public double Longitude { get; set; }

        [BsonElement("tags")]
        public IEnumerable<string> Tags { get; set; }

        [BsonElement("friends")]
        public IEnumerable<Friend> Friends { get; set; }

        [BsonElement("greeting")]
        public string Greeting { get; set;
        }
        [BsonElement("favoriteFruit")]
        public string FavoriteFruit { get; set; }
    }
}
