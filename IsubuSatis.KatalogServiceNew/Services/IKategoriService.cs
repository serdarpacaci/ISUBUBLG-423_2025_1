using AutoMapper;
using IsubuSatis.KatalogServiceNew.Dtos;
using IsubuSatis.KatalogServiceNew.EfCore;
using IsubuSatis.KatalogServiceNew.Models;
using IsubuSatis.Ortak;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;

namespace IsubuSatis.KatalogServiceNew.Services
{
    public interface IKategoriService
    {
        Task<List<KategoriDto>> GetKategoriler();
        Task KategoriOlustur(KategoriOlusturDto input);
        Task KategoriGuncelle(KategoriGuncelleDto input);
        Task KategoriSil(string id);

    }

    public class KategoriService : IKategoriService
    {
        private readonly KategoriDbContext _context;
        private readonly IMapper _mapper;

        public KategoriService(KategoriDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<KategoriDto>> GetKategoriler()
        {
            var kategoriler =  await _context.Kategoriler.ToListAsync();
            var kategoriDtos = _mapper.Map<List<KategoriDto>>(kategoriler);
            return kategoriDtos;
        }

        public Task KategoriGuncelle(KategoriGuncelleDto input)
        {
            throw new NotImplementedException();
        }

        public async Task KategoriOlustur(KategoriOlusturDto input)
        {
            var kategori = _mapper.Map<Kategori>(input);

            await _context.Kategoriler.AddAsync(kategori);

            await _context.SaveChangesAsync();
        }

        public Task KategoriSil(string id)
        {
            throw new NotImplementedException();
        }
    }
}
