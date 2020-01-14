using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers {
    public class ProductTypeController : Controller {
        public IActionResult Index() {
            var types = DataSource.GetProductTypes();
            return View(types);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductType productType) {
            if (ModelState.IsValid) {
                DataSource.AddProductType(productType);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            DataSource.RemoveProductTypeByID(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var pt = DataSource.GetProductTypeByID(id);
            return View(pt);
        }

        [HttpPost]
        public IActionResult Edit(ProductType productType) {
            if (ModelState.IsValid) {
                DataSource.UpdateProductTypeByID(productType.ID, productType);
            }

            return RedirectToAction("Index");
        }
    }
}