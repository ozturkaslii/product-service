using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductCatalog.API.DbContexts;
using ProductCatalog.API.Entities;

namespace ProductCatalog.API.Datas
{
    public class ProductUpdateDataRequest : IRequest<Product>
    {
        public ProductUpdateDataRequest(Product product)
        {
            Product = product;
        }

        public Product Product { get; set; }
    }

    public class ProductUpdateDataRequestHandler : IRequestHandler<ProductUpdateDataRequest, Product>
    {
        private readonly ProductCatalogContext _context;

        public ProductUpdateDataRequestHandler(ProductCatalogContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(ProductUpdateDataRequest request, CancellationToken cancellationToken)
        {
            var response = (_context.Products.Update(request.Product)).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return response;
        }
    }
}