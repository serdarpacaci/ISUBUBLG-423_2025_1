using IsubuSatis.KatalogServiceNew.Dtos;
using IsubuSatis.KatalogServiceNew.Services;
using IsubuSatis.Ortak;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.KatalogServiceNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController// : ControllerBase
    {
        //private readonly IKategoriService _kategoriService;

        //public KategoriController(IKategoriService kategoriService)
        //{
        //    _kategoriService = kategoriService;
        //}

        //[HttpGet]
        //public async Task<ServisSonuc<List<KategoriDto>>> GetKategoriler()
        //{
        //    var kategoriler = await _kategoriService.GetKategoriler();

        //    return ServisSonuc<List<KategoriDto>>.Basarili(kategoriler);
        //}

        //[HttpPost]
        ////[IsubuValidation<KategoriOlusturDto>()]
        //public async Task<IActionResult> KategoriOlustur(KategoriOlusturDto input)
        //{
        //    await _kategoriService.KategoriOlustur(input);

        //}

        //[HttpPut]
        //public async Task<IActionResult> KategoriGuncelle(KategoriGuncelleDto input)
        //{
        //    await _kategoriService.KategoriGuncelle(input);

        //}

        //[HttpDelete]
        //public async Task KategoriSil(string id)
        //{
        //    await _kategoriService.KategoriSil(id);
        //}
    }
}
