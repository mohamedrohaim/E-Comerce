using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class DiscountController:Controller
    {
        private readonly IDiscountRepository _discountRepository ;
        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public IActionResult Index()
        {
            var discounts=_discountRepository.GetAll();
            return View(discounts);
        }


        
    }
}
