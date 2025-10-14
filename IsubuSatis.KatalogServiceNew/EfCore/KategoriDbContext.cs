using IsubuSatis.KatalogServiceNew.Models;
using Microsoft.EntityFrameworkCore;

namespace IsubuSatis.KatalogServiceNew.EfCore
{
    public class KategoriDbContext : DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }

        public KategoriDbContext(DbContextOptions options)
            : base(options)
        {

        }



    }
}