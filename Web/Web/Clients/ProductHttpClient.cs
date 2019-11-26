using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Clients
{
    public class ProductHttpClient
    {
        private readonly HttpClient _httpClient;

        public ProductHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            var response = await _httpClient.GetAsync(@"?query= 
                        { products 
                            { id name price photoFileName } 
                        }"
                    );

            var stringResult = await response.Content.ReadAsStringAsync();
            var productsContainer = JsonConvert.DeserializeObject<Response>(stringResult);

            return productsContainer.Data.Products;
        }
    }

    public class Response
    {
        public Response(ProductsContainer productsContainer)
        {
            Data = productsContainer;
        }

        public ProductsContainer Data { get; set; }
    }

    public class ProductsContainer
    {
        public List<ProductModel> Products { get; set; }
    }
}