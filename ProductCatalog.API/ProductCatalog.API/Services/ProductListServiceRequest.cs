using AutoMapper;
using MediatR;
using ProductCatalog.API.Datas;
using ProductCatalog.API.Entities;
using ProductCatalog.API.Models.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductCatalog.API.Services
{
    public class ProductListServiceRequest : IRequest<ProductListResponseModel>
    {

    }

    public class ProductListServiceRequestHandler : IRequestHandler<ProductListServiceRequest, ProductListResponseModel>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductListServiceRequestHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProductListResponseModel> Handle(ProductListServiceRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ProductListDataRequest(), cancellationToken);
            var responseModel = _mapper.Map<List<Product>, ProductListResponseModel>(response);
            return responseModel;
        }
    }
}