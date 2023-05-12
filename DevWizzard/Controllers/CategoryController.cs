using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories=_categoryRepository.GetAll();

            return View(categories);
        }


        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Create(Category category) {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["AddedSuccessfuly"] = "Category Created Successfully";
                    _categoryRepository.Add(category);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex) {
                    TempData["FailedToCreate"] = "Faild To Create categoty";
                    return RedirectToAction(nameof(Index));
                }
            }
            else {
                TempData["FailedToCreate"] = "Faild To Create categoty";
                return RedirectToAction(nameof(Index));
            }
        
        }


        public IActionResult Delete(int id) {
            var categoty=_categoryRepository.Get(id);
            return View(categoty);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id, Category category) {

            if (id == category.category_id) {
                try
                {
                    _categoryRepository.Delete(category);
                    TempData["AddedSuccessfuly"] = "Categoty deleted Successfully";
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    //1 log exeption
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(category);

                }
            }
            else
            {
                return View(category);
            }
        }

        public IActionResult Update(int id)
        {
            var brand = _categoryRepository.Get(id);
            return View(brand);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute] int id, Category category)
        {

            if (id == category.category_id)
            {
                try
                {
                    _categoryRepository.Update(category);
                    TempData["AddedSuccessfuly"] = "Category Updeted Successfully";
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    TempData["FailedToCreate"] = "update prand failed";
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(category);

                }
            }
            else
            {
                TempData["FailedToCreate"] = "update prand failed";
                return View(category);
            }
        }



    }
}
