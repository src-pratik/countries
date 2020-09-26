namespace Basics.Countries.MongoStorage
{
    public class CountryDBSettings : IMongoDBSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}