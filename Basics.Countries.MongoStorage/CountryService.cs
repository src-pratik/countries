using Basics.Countries.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Basics.Countries.MongoStorage
{
    public class CountryService
    {
        private readonly IMongoCollection<Country> _countries;

        public CountryService(IMongoDBSettings settings)
        {
            //MongoDB Client, which enables us to communicate with the database
            var client = new MongoClient(settings.ConnectionString);
            //Database within the MongoDB instance, in which the collections are to be referred.
            var database = client.GetDatabase(settings.DatabaseName);

            //Get the required collection from the database
            _countries = database.GetCollection<Country>("Country");
        }

        //Get Country by Id
        public Country Get(string id)
        {
            return _countries.Find<Country>(country => country.Id == id).FirstOrDefault();
        }

        //Get all countries
        //Projectons is a custom implementation to wrap up query projection definitions
        //ProjectionDefinitions are used to include or exclude fields from result set.
        public List<Country> Get(Projections projections = null)
        {
            var filter = Builders<Country>.Filter.Empty;

            var projDefinitions = projections.ToDefinitions<Country>();

            var projection = Builders<Country>.Projection.Combine(projDefinitions);
            var result = _countries.Find(filter).Project<Country>(projection).ToList();

            return result;
        }

        //Create country
        public Country Create(Country country)
        {
            _countries.InsertOne(country);
            return country;
        }

        //Update Country
        public void Update(string id, Country countryIn)
        {
            _countries.ReplaceOne(Country => Country.Id == id, countryIn);
        }

        //Remove Country
        public void Remove(Country countryIn)
        {
            _countries.DeleteOne(country => country.Id == countryIn.Id);
        }

        //Remove Country By Id
        public void Remove(string id)
        {
            _countries.DeleteOne(country => country.Id == id);
        }
    }
}