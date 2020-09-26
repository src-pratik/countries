using MongoDB.Bson.Serialization.Attributes;

namespace Basics.Countries.Entities
{
    public class FlagImage
    {
        [BsonId]
        public string Id { get; set; }

        public byte[] Value { get; set; }
    }
}