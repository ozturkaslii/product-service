using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProductCatalog.API.Datas;
using ProductCatalog.API.Entities;
using ProductCatalog.API.Models.Requests;
using ProductCatalog.API.Models.Responses;

namespace ProductCatalog.API.Services
{
    public class ProductCreateServiceRequest : IRequest<ProductCreateResponseModel>
    {
        public ProductCreateServiceRequest(ProductCreateRequestModel model)
        {
            Model = model;
        }

        public ProductCreateRequestModel Model { get; set; }
    }

    public class ProductCreateServiceRequestHandler : IRequestHandler<ProductCreateServiceRequest, ProductCreateResponseModel>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductCreateServiceRequestHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProductCreateResponseModel> Handle(ProductCreateServiceRequest request, CancellationToken cancellationToken)
        {
            var mappedEntity = _mapper.Map<ProductCreateRequestModel, Product>(request.Model);
            mappedEntity.LastUpdated = DateTimeOffset.Now;
            var response = await _mediator.Send(new ProductCreateDataRequest(mappedEntity), cancellationToken);

            var responseModel = _mapper.Map<Product, ProductCreateResponseModel>(response);
            return responseModel;
        }
    }
}