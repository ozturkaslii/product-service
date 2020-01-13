using AutoMapper;
using MediatR;
using ProductCatalog.API.Datas;
using ProductCatalog.API.Entities;
using ProductCatalog.API.Models.Requests;
using ProductCatalog.API.Models.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductCatalog.API.Services
{
    public class ProductUpdateServiceRequest : IRequest<ProductUpdateResponseModel>
    {
        public ProductUpdateServiceRequest(int productId, ProductUpdateRequestModel model)
        {
            ProductId = productId;
            Model = model;
        }

        public int ProductId { get; set; }
        public ProductUpdateRequestModel Model { get; set; }
    }

    public class ProductUpdateServiceRequestHandler : IRequestHandler<ProductUpdateServiceRequest, ProductUpdateResponseModel>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductUpdateServiceRequestHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProductUpdateResponseModel> Handle(ProductUpdateServiceRequest request, CancellationToken cancellationToken)
        {
            var existedEntity = await _mediator.Send(new ProductGetDataRequest(request.ProductId), cancellationToken);
            existedEntity.Name = request.Model.Name;
            existedEntity.Code = request.Model.Code;
            existedEntity.Price = request.Model.Price;
            existedEntity.Photo = request.Model.Photo;
            existedEntity.LastUpdated = DateTimeOffset.Now;

            var response = await _mediator.Send(new ProductUpdateDataRequest(existedEntity), cancellationToken);
            var responseModel = _mapper.Map<Product, ProductUpdateResponseModel>(response);
            return responseModel;
        }
    }
}