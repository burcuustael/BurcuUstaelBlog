using Microsoft.AspNetCore.Mvc;

namespace BurcuUstaelBlog.Controllers
{
    public class IletisimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collections)
        {
            ViewBag.Name = collections["_name"];
            ViewBag.Email = collections["email"];
            ViewBag.Mesaj = collections["mesaj"];
            ViewBag.Kontrol = collections["kontrol"][0];

            return View();
        }
    }
}
