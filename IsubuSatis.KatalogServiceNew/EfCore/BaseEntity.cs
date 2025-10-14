using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Reflection;

namespace IsubuSatis.KatalogServiceNew.EfCore
{
    public class BaseEntity
    {
        [BsonElement("_id")] 
        public Guid Id { get; set; }
    }
}
