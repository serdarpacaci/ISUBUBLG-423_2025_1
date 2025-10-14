using FluentValidation;
using IsubuSatis.KatalogServiceNew.Dtos;

namespace IsubuSatis.KatalogServiceNew.Validators
{
    public class KategoriOlusturDtoValidator :
        AbstractValidator<KategoriOlusturDto>
    {
        public KategoriOlusturDtoValidator()
        {
            RuleFor(x => x.Ad)
                .NotEmpty().WithMessage("Ad boş bırakılamaz")
                .Length(2, 200).WithMessage("Ad 2 ile 200 karakter uzunluğunda olabilir");

        }
    }
}
