using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductCatalog.API.Datas;

namespace ProductCatalog.API.Services
{
    public class ProductDeleteServiceRequest : IRequest<bool>
    {
        public ProductDeleteServiceRequest(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }
    }

    public class ProductDeleteServiceRequestHandler : IRequestHandler<ProductDeleteServiceRequest, bool>
    {
        private readonly IMediator _mediator;

        public ProductDeleteServiceRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> Handle(ProductDeleteServiceRequest request, CancellationToken cancellationToken)
        {
            var existedEntity = await _mediator.Send(new ProductGetDataRequest(request.ProductId), cancellationToken);
            var response = await _mediator.Send(new ProductDeleteDataRequest(existedEntity), cancellationToken);
            return response.Id == request.ProductId;
        }
    }
}