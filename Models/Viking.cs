using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LuftbornTask.Models
{
    public class Viking
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public VikingGender Gender { get; set; }
        public VikingRank Rank { get; set; }
    }
}
