using Microsoft.AspNetCore.Mvc;

namespace BurcuUstaelBlog.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi =="admin" && sifre== "123")
            {
                HttpContext.Session.SetString("user", kullaniciAdi);
                HttpContext.Session.SetInt32("sifre", 123);
                HttpContext.Session.SetString("userguid",Guid.NewGuid().ToString());
                return RedirectToAction("SessionOku");
            }
            return View();
        }


        public IActionResult SessionOku()
        {
            TempData["SessionBilgi"]= HttpContext.Session.GetString("user");
            TempData["userGuid"] = HttpContext.Session.GetString("userguid");
            return View();
        }

        public IActionResult SessionSil()
        {
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("userguid");

            return RedirectToAction("Index");
        }


    }
}
