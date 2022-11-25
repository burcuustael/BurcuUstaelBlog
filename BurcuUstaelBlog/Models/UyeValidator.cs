using FluentValidation;

namespace BurcuUstaelBlog.Models
{
    public class UyeValidator : AbstractValidator<Uye>
    {
        public UyeValidator() 

        { 
        
            RuleFor(x=>x.Id).NotEmpty().WithMessage("Id Alanı Boş Geçilemez");
            RuleFor(x => x.AdSoyad).NotNull().WithMessage("Ad Soyad Boş Geçilemez");
            RuleFor(x => x.Eposta).EmailAddress().NotEmpty().WithMessage("E posta Boş Geçilemez");
            RuleFor(x =>x.Telefon).MinimumLength(10).MaximumLength(10).NotEmpty().WithMessage("Telefon Boş Geçilemez");
            RuleFor(x => x.KullaniciAdi).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.Password).NotNull().WithMessage("Şifre Boş Geçilemez");
                                
        }
    }
}
