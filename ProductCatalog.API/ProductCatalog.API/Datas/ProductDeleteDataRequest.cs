using MediatR;
using ProductCatalog.API.DbContexts;
using ProductCatalog.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ProductCatalog.API.Datas
{
    public class ProductDeleteDataRequest : IRequest<Product>
    {
        public ProductDeleteDataRequest(Product product)
        {
            Product = product;
        }

        public Product Product { get; set; }
    }

    public class ProductDeleteDataRequestHandler : IRequestHandler<ProductDeleteDataRequest, Product>
    {
        private readonly ProductCatalogContext _context;

        public ProductDeleteDataRequestHandler(ProductCatalogContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(ProductDeleteDataRequest request, CancellationToken cancellationToken)
        {
            var response = _context.Products.Remove(request.Product).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return response;
        }
    }
}