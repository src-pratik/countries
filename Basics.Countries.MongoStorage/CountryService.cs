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
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _countries = database.GetCollection<Country>("Country");
        }

        public Country Get(string id)
        {
            return _countries.Find<Country>(country => country.Id == id).FirstOrDefault();
        }

        public List<Country> Get(Projections projections = null)
        {
            var filter = Builders<Country>.Filter.Empty;

            var projDefinitions = projections.ToDefinitions<Country>();

            var projection = Builders<Country>.Projection.Combine(projDefinitions);
            var result = _countries.Find(filter).Project<Country>(projection).ToList();

            return result;
        }

        public Country Create(Country country)
        {
            _countries.InsertOne(country);
            return country;
        }

        public void Update(string id, Country countryIn)
        {
            _countries.ReplaceOne(Country => Country.Id == id, countryIn);
        }

        public void Remove(Country countryIn)
        {
            _countries.DeleteOne(country => country.Id == countryIn.Id);
        }

        public void Remove(string id)
        {
            _countries.DeleteOne(country => country.Id == id);
        }
    }
}