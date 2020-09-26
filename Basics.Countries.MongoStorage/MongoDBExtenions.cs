using MongoDB.Driver;
using System.Collections.Generic;

namespace Basics.Countries.MongoStorage
{
    /// <summary>
    /// Extention methods for querying MongoDB
    /// </summary>
    public static class MongoDBExtenions
    {
        /// <summary>
        /// Builds up a list of projections for query.
        /// </summary>
        /// <typeparam name="T">Type of document</typeparam>
        /// <param name="projections">Instance of Projections.</param>
        /// <returns></returns>
        public static List<ProjectionDefinition<T>> ToDefinitions<T>(this Projections projections)
        {
            var definitions = new List<ProjectionDefinition<T>>();

            if (projections != null)
            {
                foreach (var item in projections.FieldNames)
                {
                    switch (projections.Type)
                    {
                        case ProjectionTypeEnum.Include:
                            definitions.Add(Builders<T>.Projection.Include(item));
                            break;
                        case ProjectionTypeEnum.Exclude:
                            definitions.Add(Builders<T>.Projection.Exclude(item));
                            break;
                        default:
                            break;
                    }                    
                }
            }

            return definitions;
        }
    }

}