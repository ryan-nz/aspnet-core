using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PilotWorksAPI.Core.DataEntity
{
    public class Product
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public double  Price { get; set; }
    }
}
