using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Basics.Countries.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public RecordStatusTypeEnum StatusType { get; set; }
    }

    public class Country : BaseEntity
    {
        public string Alpha3Code { get; set; }
        public string Alpha2Code { get; set; }
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Zoom { get; set; }
    }

    public enum RecordStatusTypeEnum
    {
        Active = 1,
        Suspended = 2,
        Deleted = 3
    }
}