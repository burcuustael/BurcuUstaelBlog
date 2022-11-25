using BurcuUstaelBlog.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BurcuUstaelBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IValidator<Uye> _validator;

        public HomeController(ILogger<HomeController> logger, IValidator<Uye> validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task<IActionResult> KayitOl(Uye uye)
        {
            FluentValidation.Results.ValidationResult result = await _validator.ValidateAsync(uye);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.Remove(error.PropertyName);
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return View("KayitOl", uye);

            }
            TempData["mesaj"] = "Kayıt Başarılı";

            return RedirectToAction("Index");
        }

        public IActionResult KayitOl()
        {
            return View();
        }



        [HttpPost]
        public IActionResult UyeGirisi(Uye uye)
        {
            return View();
        }

        public IActionResult UyeGirisi()
        {
            return View();
        }

    }
}