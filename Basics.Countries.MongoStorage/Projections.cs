namespace Basics.Countries.MongoStorage
{
    /// <summary>
    /// Projections is used to define to retrive or exlude the desired fields from Document.
    /// This can be then used to build the ProjectionDefinition to query a collection.
    /// </summary>
    public class Projections
    {
        /// <summary>
        /// Type of projection
        /// </summary>
        public ProjectionTypeEnum Type { get; set; }
        /// <summary>
        /// Collection of field names.
        /// </summary>
        public string[] FieldNames { get; set; }
    }

}