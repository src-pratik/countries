using Basics.Countries.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Basics.Countries.MongoStorage
{
    public class FlagService
    {
        private readonly IMongoCollection<FlagImage> _flagImages;

        public FlagService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _flagImages = database.GetCollection<FlagImage>("Flag");
        }

        public List<FlagImage> Get() =>
         _flagImages.Find(optionvalue => true).ToList();

        public FlagImage Get(string id) =>
           _flagImages.Find<FlagImage>(flagImage => flagImage.Id == id).FirstOrDefault();

        public FlagImage Create(FlagImage flagImage)
        {
            _flagImages.InsertOne(flagImage);
            return flagImage;
        }

        public void Update(string id, FlagImage flagImageIn) =>
          _flagImages.ReplaceOne(flagImage => flagImage.Id == id, flagImageIn);

        public void Remove(FlagImage flagImageIn) =>
           _flagImages.DeleteOne(flagImage => flagImage.Id == flagImageIn.Id);

        public void Remove(string id) =>
            _flagImages.DeleteOne(flagImage => flagImage.Id == id);
    }
}