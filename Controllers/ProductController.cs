using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers {
    public class ProductController : Controller {
        public IActionResult Index() {
            ViewData["Title"] = "All Products";
            var products = DataSource.GetProducts();
            return View(products);
        }

        public IActionResult IndexByTypeID(int id) {
            var pt = DataSource.GetProductTypeByID(id);
            ViewData["Title"] = $"Products of {pt.Name}";
            var products = DataSource.GetProductsByTypeID(id);
            return View("Index", products); // reuse Index view
        }

        public IActionResult ShowDetail(int id) {
            var product = DataSource.GetProductByID(id);
            if (product != null)
                return View("Detail", product);
            else
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product) {
            if (ModelState.IsValid)
                DataSource.AddProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            DataSource.RemoveProductByID(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var product = DataSource.GetProductByID(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product) {
            if (ModelState.IsValid)
                DataSource.UpdateProductByID(product.ID, product);
            return RedirectToAction("Index");
        }
    }
}