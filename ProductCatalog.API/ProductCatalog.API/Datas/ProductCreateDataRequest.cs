using MediatR;
using ProductCatalog.API.DbContexts;
using ProductCatalog.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ProductCatalog.API.Datas
{
    public class ProductCreateDataRequest : IRequest<Product>
    {
        public ProductCreateDataRequest(Product product)
        {
            Product = product;
        }

        public Product Product { get; set; }
    }

    public class ProductCreateDataRequestHandler : IRequestHandler<ProductCreateDataRequest, Product>
    {
        private readonly ProductCatalogContext _context;

        public ProductCreateDataRequestHandler(ProductCatalogContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(ProductCreateDataRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.Products.AddAsync(request.Product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return response.Entity;
        }
    }
}