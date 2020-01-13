using Newtonsoft.Json;
using ProductCatalog.API;
using ProductCatalog.API.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductCatalog.Test
{
    public class ProductCatalogTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public ProductCatalogTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Test_Get_ProductItems()
        {
            //arrange
            var request = "api/Products";

            //act
            var response = await _client.GetAsync(request);

            //assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Test_Get_SingleProductItem()
        {
            //arrange
            var request = "api/Products/1";

            //act
            var response = await _client.GetAsync(request);

            //assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Test_Post_ProductItem()
        {
            //arrange
            var request = "api/Products";

            //act
            var response = await _client.PostAsync(request, new StringContent(
                JsonConvert.SerializeObject(new Product
                {
                    Name = "Test Product Create",
                    Code = "TST1",
                    Price = 15.00m,
                    LastUpdated = DateTimeOffset.Now
                }), Encoding.UTF8, "application/json"));

            //assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Test_Put_ProductItem()
        {
            //arrange
            var request = "api/Products/1";

            //act
            var response = await _client.PutAsync(request, new StringContent(
                JsonConvert.SerializeObject(new Product
                {
                    Name = "Test Product Update",
                    Code = "CC12",
                    Price = 25.00m,
                    LastUpdated = DateTimeOffset.Now
                }), Encoding.UTF8, "application/json"));
            //assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Test_Delete_SingleProductItem()
        {
            //arrange
            var request = "api/Products";

            //act
            var createResponse = await _client.PostAsync(request, new StringContent(
                JsonConvert.SerializeObject(new Product
                {
                    Name = "Test Product to Delete",
                    Code = "TSTD1",
                    Price = 15.00m,
                    LastUpdated = DateTimeOffset.Now
                }), Encoding.UTF8, "application/json"));

            var jsonResponse = await createResponse.Content.ReadAsStringAsync();
            var createdItem = JsonConvert.DeserializeObject<Product>(jsonResponse);

            var deleteResponse = await _client.DeleteAsync($"{request}/{createdItem.Id}");

            //assert
            createResponse.EnsureSuccessStatusCode();
            deleteResponse.EnsureSuccessStatusCode();
        }
    }
}
