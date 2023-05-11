using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepositoty;
        public BrandController(IBrandRepository brandRepositoty)
        {
            _brandRepositoty = brandRepositoty;
        }

        public IActionResult Index()
        {
            var brands=_brandRepositoty.GetAll();

            return View(brands);
        }
    }
}
