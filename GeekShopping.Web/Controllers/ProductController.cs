﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if(ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(model);
                if(response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(Guid id)
        {
            var product = await _productService.FindProductById(id);
            if(product == null)
            {
                return NotFound();
            }

            return View(product);

        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(model);
                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ProductDelete(Guid id)
        {
            var model = await _productService.FindProductById(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var response = await _productService.DeleteProductById(model.Id);
            if (response != null)
            {
                return RedirectToAction(nameof(ProductIndex));
            }


            return View(model);
        }
    }
}
