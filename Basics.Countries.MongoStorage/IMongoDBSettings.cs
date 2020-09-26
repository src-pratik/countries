namespace Basics.Countries.MongoStorage
{
    public interface IMongoDBSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }

}