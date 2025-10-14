﻿using AutoMapper;
using KatalogService.Dtos;
using KatalogService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace KatalogService.Services
{
    public class KategoriService : IKategoriService
    {
        private readonly IMongoCollection<Kategori> _kategoriCollection;
        private readonly IMapper _mapper;

        public KategoriService(IOptions<MongoDbSettings> setting,
            IMapper mapper)
        {
            var client = new MongoClient(setting.Value.ConnectionUrl);
            var database = client.GetDatabase(setting.Value.Database);
            _kategoriCollection = database.GetCollection<Kategori>(MongoDbTables.KategoriTable);

            _mapper = mapper;
        }


        public async Task<List<KategoriDto>> GetKategoriler()
        {
            var kategoriler = await _kategoriCollection.AsQueryable()
                .ToListAsync();

            return _mapper.Map<List<KategoriDto>>(kategoriler);
        }
        
        public async Task KategoriOlustur(KategoriOlusturDto input)
        {
            var kategori = _mapper.Map<Kategori>(input);

            await _kategoriCollection.InsertOneAsync(kategori);
        }

        public async Task KategoriGuncelle(KategoriGuncelleDto input)
        {
            var kategori = _kategoriCollection.AsQueryable()
                .Where(x => x.Id == input.Id)
                .FirstOrDefault();

            _mapper.Map(input, kategori);

            await _kategoriCollection.ReplaceOneAsync(
                Builders<Kategori>.Filter.Eq(x => x.Id, input.Id), kategori);
        }

        public async Task KategoriSil(string id)
        {
            await _kategoriCollection.DeleteOneAsync(
                Builders<Kategori>.Filter.Eq(x => x.Id, id));
        }
    }
}
