using AutoMapper;
using MediatR;
using ProductCatalog.API.Datas;
using ProductCatalog.API.Entities;
using ProductCatalog.API.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace ProductCatalog.API.Services
{
    public class ProductGetServiceRequest : IRequest<ProductGetResponseModel>
    {
        public ProductGetServiceRequest(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }
    }

    public class ProductGetServiceRequestHandler : IRequestHandler<ProductGetServiceRequest, ProductGetResponseModel>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductGetServiceRequestHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProductGetResponseModel> Handle(ProductGetServiceRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ProductGetDataRequest(request.ProductId), cancellationToken);
            var responseModel = _mapper.Map<Product, ProductGetResponseModel>(response);
            return responseModel;
        }
    }
}