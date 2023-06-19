using DapperMVC.Data.Models.Domain;
using DapperMVC.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DapperMvcDemo.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(product);
                bool addProductResult = await _productRepo.AddAsync(product);
                if (addProductResult)
                    TempData["msg"] = "Record Successfully added";
                else
                    TempData["msg"] = "Record does not get added";
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not added";
            }
            return RedirectToAction(nameof(Add));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            //if (product == null)
            //    return NotFound();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(product);
                var updateResult = await _productRepo.UpdateAsync(product);
                if (updateResult)
                    TempData["msg"] = "Updated succesfully";
                else
                    TempData["msg"] = "Could not updated";

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not updated";
            }
            return View(product);
        }

        public async Task<IActionResult> DisplayAll()
        {
            var prod = await _productRepo.GetAllAsync();
            return View(prod);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var deleteResult = await _productRepo.DeleteAsync(id);
            return RedirectToAction(nameof(DisplayAll));
        }

    }
}
