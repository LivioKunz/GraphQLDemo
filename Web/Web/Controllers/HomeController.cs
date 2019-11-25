using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Clients;

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

        //public async Task<IActionResult> AddSimilairProduct(int productId)
        //{
        //    _productGraphClient.AddSimilairProduct()
        //}
    }
}
