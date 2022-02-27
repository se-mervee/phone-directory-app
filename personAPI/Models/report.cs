using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonAPI.Models
{
    public class report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string reportDate { get; set; }
        public string status { get; set; }
        public string location { get; set; }
        public int numberOfPeople { get; set; }
        public int numberOfPhone { get; set; }
    }
}
