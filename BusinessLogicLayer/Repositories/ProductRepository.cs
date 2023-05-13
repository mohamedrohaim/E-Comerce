using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories
{
    public class ProductRepository:GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public  IEnumerable<ProductDetails> getProductsWithAllData()
        {
            IEnumerable<ProductDetails> productsDetails=new List<ProductDetails>();
            var products = (_appDbContext.Products
                .Join(
                _appDbContext.Brands,
                p => p.brand_id,
                b => b.brand_id,
                (p, b) => new
                {
                    productId = p.product_id,
                    productName = p.product_name,
                    productBrand = b.brand_name,
                    CategoryId = p.category_id,
                    productPrice = p.price,
                    ProductImage = p.image,
                    productCreatedAt = p.created_at,
                    productUpdatedAt = p.updated_at,
                    productQuantity = p.quantity,
                    productDescription = p.description,
                    productPrandId=p.brand_id,


                }).Join(
                _appDbContext.Categories,
                product => product.CategoryId,
                category => category.category_id,
                  (product, category) => new
                  {
                      productId = product.productId,
                      productName = product.productName,
                      productBrand = product.productBrand,
                      categoryName = category.category_name,
                      productPrice = product.productPrice,
                      ProductImage = product.ProductImage,
                      productCreatedAt = product.productCreatedAt,
                      productUpdatedAt = product.productUpdatedAt,
                      productQuantity = product.productQuantity,
                      productDescription = product.productDescription,
                      categotyId=product.CategoryId,
                      brandId=product.productPrandId,
                      


                  }
            ));
            foreach (var product in products)
            {
                var productDetails = new ProductDetails
                {
                   product_id=product.productId,
                   product_name=product.productName,
                   brand_name=product.productBrand,
                   description=product.productDescription,
                   image=product.ProductImage,
                   price=product.productPrice,
                   quantity=product.productQuantity,
                   updated_at=product.productUpdatedAt,
                   created_at=product.productCreatedAt,
                   category_name=product.categoryName,
                   brand_id=product.brandId,
                   category_id=product.categotyId,

                };

                productsDetails = productsDetails.Append(productDetails);
            }


            return productsDetails;

        }
    }
}
