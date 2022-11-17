using BurcuUstaelBlog.Models;
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
        public IActionResult Index(Bilgiler bilgi)
        {
            if(ModelState.IsValid)
            {

            }

            if(!ModelState.IsValid) {

                ModelState.AddModelError("", "Lütfen Zorunlu Alanları Doldurunuz");
            }
            
            return View(bilgi);
        }
    }
}
