using IsubuSatis.KatalogServiceNew.EfCore;
using MongoDB.Bson.Serialization.Attributes;

namespace IsubuSatis.KatalogServiceNew.Models
{
    public class Kategori : BaseEntity
    {
        public string Ad { get; set; }
    }
}
