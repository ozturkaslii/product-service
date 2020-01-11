using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.DbContexts;
using ProductCatalog.API.Entities;
using ProductCatalog.API.Models.Responses;

namespace ProductCatalog.API.Datas
{
    public class ProductListDataRequest : IRequest<List<Product>>
    {

    }

    public class ProductListDataRequestHandler : IRequestHandler<ProductListDataRequest, List<Product>>
    {
        private readonly ProductCatalogContext _context;

        public ProductListDataRequestHandler(ProductCatalogContext catalog)
        {
            _context = catalog;
        }

        public async Task<List<Product>> Handle(ProductListDataRequest request, CancellationToken cancellationToken)
        {
            var response = await _context.Products.ToListAsync(cancellationToken);
            return response;
        }
    }
}