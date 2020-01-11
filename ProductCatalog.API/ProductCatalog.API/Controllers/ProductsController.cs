using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Models.Requests;
using ProductCatalog.API.Models.Responses;
using ProductCatalog.API.Services;

namespace ProductCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all product items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ProductListResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            var response = await _mediator.Send(new ProductListServiceRequest());
            return Ok(response);
        }

        /// <summary>
        /// Get product by product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{productId}")]
        [ProducesResponseType(typeof(ProductGetResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] int productId)
        {
            var response = await _mediator.Send(new ProductGetServiceRequest(productId));
            return Ok(response);
        }

        /// <summary>
        /// Add product to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProductCreateResponseModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] ProductCreateRequestModel model)
        {
            var response = await _mediator.Send(new ProductCreateServiceRequest(model));
            return Ok(response);
        }
    }
}