using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using Web.Models;
using System.Collections.Generic;

namespace Web.Clients
{
    public class ProductGraphClient
    {
        private readonly GraphQLClient _client;

        public ProductGraphClient(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @" 
               query productQuery($productId: ID!) {
                  product(id: $productId) {
                    id
                    name
                    price
                    photoFileName
                    description
                    similarProducts{
                      name
                      photoFileName
                    }
                  }
                }",
                Variables = new { productId = id }
            };
            var response = await _client.PostAsync(query);
            var test = response.GetDataFieldAs<ProductModel>("product");
            return test;
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            var stringquery = @"{ products
                    { id name price  }
                }";
            var query = new GraphQLRequest
            {
                Query = stringquery
            };

            var response = await _client.PostAsync(query);

            var response2 = await _client.PostQueryAsync(stringquery);
            var test = response2.GetDataFieldAs<List<ProductModel>>("products");

            return response.GetDataFieldAs<List<ProductModel>>("products");
        }

        public async Task<ProductModel> AddProduct(ProductInputModel product)
        {
            var query = new GraphQLRequest
            {
                Query = @" mutation($productIn: ProductInput!) {
                              createProduct(productInput: $productIn) {
                                id
                                name
                                price
                                photoFileName
                                description
                              }
                            }",
                Variables = new
                {
                    productIn = product
                }
            };

            var respone = await _client.PostAsync(query);                       
            return respone.GetDataFieldAs<ProductModel>("createProduct");
        }     
    }
}