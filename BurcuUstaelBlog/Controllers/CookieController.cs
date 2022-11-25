using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BurcuUstaelBlog.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CookieOlustur(string kullaniciAdi, string sifre) 
        {

            if (kullaniciAdi == "admin" && sifre == "123456")
            {
                CookieOptions cookieAyarlari = new()
                {
                    Expires = DateTime.Now.AddMinutes(1),
                };

                Response.Cookies.Append("cookie", kullaniciAdi, cookieAyarlari);
                Response.Cookies.Append("sifre", sifre, cookieAyarlari);
                Response.Cookies.Append("userguid", Guid.NewGuid().ToString());
                return RedirectToAction("CookieOku");
            }
            else TempData["mesaj"] = "Giriş Başarısız";

            return RedirectToAction("Index");
        }


        public IActionResult CookieOku()
        {
            if (Request.Cookies["userguid"] is null)
                return RedirectToAction("Index");

            TempData["kullaniciadi"] = Request.Cookies["cookie"];
            TempData["kullaniciguid"] = Request.Cookies["userguid"];
            return View();

        }
        
        public IActionResult CookieSil()
        {
            Response.Cookies.Delete("cookie");
            Response.Cookies.Delete("userguid");
            Response.Cookies.Delete("sifre");
            return RedirectToAction("CookieOku");

        }

    }
}
