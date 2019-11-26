using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Clients;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private ProductHttpClient _httpClient;
        private ProductGraphClient _productGraphClient;

        public HomeController(ProductHttpClient httpClient, ProductGraphClient productGraphClient)
        {
            _httpClient = httpClient;
            _productGraphClient = productGraphClient;
        }

        public async Task<IActionResult> Index()
        {
            var responseModel = await _httpClient.GetProducts();
            return View(responseModel);
        }

        public async Task<IActionResult> Index2()
        {
            var responseModel = await _productGraphClient.GetProducts();
            return View(responseModel);
        }

        public async Task<IActionResult> ProductDetail(int productId)
        {
            var responseModel = await _productGraphClient.GetProduct(productId);
            return View(responseModel);
        }

        public IActionResult AddProduct()
        {
            return View(new ProductInputModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductInputModel input)
        {
            var product = await _productGraphClient.AddProduct(input);
            return RedirectToAction("ProductDetail", new { productId = product.Id });
        }
    }
}
