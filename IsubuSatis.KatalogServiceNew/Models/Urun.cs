using IsubuSatis.KatalogServiceNew.EfCore;
using MongoDB.Bson.Serialization.Attributes;

namespace IsubuSatis.KatalogServiceNew.Models
{
    public class Urun : BaseEntity
    {
        public string Ad { get; set; }

        public decimal Fiyat { get; set; }
        public DateTime EklenmeTarihi { get; set; }

        public string KategoriId { get; set; }

        public Kategori KategoriFk { get; set; }
    }
}
