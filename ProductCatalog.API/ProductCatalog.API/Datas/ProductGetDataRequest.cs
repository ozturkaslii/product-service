using MediatR;
using ProductCatalog.API.DbContexts;
using ProductCatalog.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ProductCatalog.API.Datas
{
    public class ProductGetDataRequest : IRequest<Product>
    {
        public ProductGetDataRequest(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }
    }

    public class ProductGetDataRequestHandler : IRequestHandler<ProductGetDataRequest, Product>
    {
        private readonly ProductCatalogContext _context;


        public ProductGetDataRequestHandler(ProductCatalogContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(ProductGetDataRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.Products.FindAsync(request.ProductId);
            return response;
        }
    }
}