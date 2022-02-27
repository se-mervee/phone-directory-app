using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonAPI.Models
{
    public class person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string company { get; set; }
        public contactInfo contactInfo { get; set; }
    }
}
