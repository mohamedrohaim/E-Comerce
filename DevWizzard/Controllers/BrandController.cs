using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Authorize]
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


        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Create(Brand brand) {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["AddedSuccessfuly"] = "Brand Created Successfully";
                    _brandRepositoty.Add(brand);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex) {
                    TempData["FailedToCreate"] = "Faild To Create";
                    return RedirectToAction(nameof(Index));
                }
            }
            else {
                TempData["FailedToCreate"] = "Faild To Create";
                return RedirectToAction(nameof(Index));
            }
        
        }


        public IActionResult Delete(int id) {
            var brand=_brandRepositoty.Get(id);
            return View(brand);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id, Brand brand) {

            if (id == brand.brand_id) {
                try
                {
                    _brandRepositoty.Delete(brand);
                    TempData["AddedSuccessfuly"] = "Brand deleted Successfully";
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    //1 log exeption
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(brand);

                }
            }
            else
            {
                return View(brand);
            }
        }

        public IActionResult Update(int id)
        {
            var brand = _brandRepositoty.Get(id);
            return View(brand);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute] int id, Brand brand)
        {

            if (id == brand.brand_id)
            {
                try
                {
                    _brandRepositoty.Update(brand);
                    TempData["AddedSuccessfuly"] = "Brand Updeted Successfully";
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    TempData["AddedSuccessfuly"] = "update prand failed";
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(brand);

                }
            }
            else
            {
                TempData["FailedToCreate"] = "update prand failed";
                return View(brand);
            }
        }



    }
}
