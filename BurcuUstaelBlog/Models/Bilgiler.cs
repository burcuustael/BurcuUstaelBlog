using System.ComponentModel.DataAnnotations;

namespace BurcuUstaelBlog.Models
{
    public class Bilgiler
    {
        public int Id{ get; set; }

        [Required(ErrorMessage="{0} alanını boş geçemezsiniz")]
        public string IsimSoyisim { get; set; }

        [Required(ErrorMessage ="{0} alanını boş geçemezsiniz")]
        [EmailAddress(ErrorMessage ="Yanlış E posta Biçimi")]

        public string Eposta { get; set; }

        [StringLength(500)]
        public string Mesaj{ get; set; }

        [Phone]
        public string? Telefon { get; set; }

        [Required(ErrorMessage ="{0} alanını boş geçemezsiniz")]
        public string TcKimlikNo { get; set; }

    }
}
