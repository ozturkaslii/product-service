using System;

namespace ProductCatalog.API.Models.Responses
{
    public class ProductGetResponseModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
    }
}