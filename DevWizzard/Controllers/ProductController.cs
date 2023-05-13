using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductController(IProductRepository productRepository,IBrandRepository brandRepository,ICategoryRepository categoryRepository ) { 
            _productRepository= productRepository;
            _brandRepository= brandRepository;
            _categoryRepository= categoryRepository;
           
        }
        public IActionResult Index()
        {
            var products = _productRepository.getProductsWithAllData().ToList();
            return View(products);
        }

        public IActionResult Details(int id,string VeiwName="Details")
        {
            IEnumerable<Brand> myList=new List<Brand>();
            myList=_brandRepository.GetAll();
            ViewData["MyList"] = myList;
            var  products = _productRepository.getProductsWithAllData().ToList();
            var product=products.Where(p=>p.product_id==id).FirstOrDefault();
            return View(VeiwName, product);
        }

        public IActionResult Update(int id)
        {

            return Details(id,"Update");
        }

  
        public Product mappingProduct(Product product,ProductDetails productDetails) {
            product.product_name = productDetails.product_name;
            product.price = productDetails.price;
            product.description = productDetails.description;
            product.brand_id = productDetails.brand_id;
            product.category_id = productDetails.category_id;
            product.image = productDetails.image;
            product.quantity = productDetails.quantity;

            return product;


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute] int id, ProductDetails productDetails)
        {

            if (id == productDetails.product_id)
            {
                try
                {
                   var product= _productRepository.Get(id);
                    product=mappingProduct(product, productDetails);
                    product.updated_at= DateTime.Now;
                    _productRepository.Update(product);
                    TempData["AddedSuccessfuly"] = "product Updeted Successfully";
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    TempData["FailedToCreate"] = "update product failed";
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(productDetails);

                }
            }
            else
            {
                TempData["FailedToCreate"] = "update product failed";
                return View(productDetails);
            }
        }

    }
}
