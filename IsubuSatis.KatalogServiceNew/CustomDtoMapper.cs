using AutoMapper;
using IsubuSatis.KatalogServiceNew.Dtos;
using IsubuSatis.KatalogServiceNew.Models;

namespace IsubuSatis.KatalogServiceNew
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Kategori, KategoriOlusturDto>().ReverseMap();
            CreateMap<Kategori, KategoriGuncelleDto>().ReverseMap();
            CreateMap<Kategori, KategoriDto>().ReverseMap();


            CreateMap<Urun, CreateOrUpdateUrunDto>().ReverseMap();
            CreateMap<Urun, UrunDto>().ReverseMap();

        }
    }
}
