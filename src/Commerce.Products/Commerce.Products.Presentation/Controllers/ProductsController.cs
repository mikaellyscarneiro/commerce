﻿using Commerce.Products.Application.V1.Dtos.ProductContext.Request;
using Commerce.Products.Application.V1.Dtos.ProductContext.Response;
using Commerce.Products.Application.V1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Products.Presentation.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, [FromServices] IProductAppService productAppService)
        {
                var product = await productAppService.GetByIdAsync(id);

                if (product == null)
                {
                    var notFoundProblem = new ProblemDetails
                    {
                        Title = "Recurso não encontrado",
                        Detail = $"Não foi possivel encontrar um produto com o ID: {id}",
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4"
                    };

                    return NotFound(notFoundProblem);
                }

                return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateProductDto request, [FromServices] IProductAppService productAppService)
        {
                var createdProduct = await productAppService.CreateAsync(request);

                return StatusCode(StatusCodes.Status201Created, createdProduct);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] IProductAppService productAppService)
        {
                await productAppService.DeleteAsync(id);

                return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateProductDto request, [FromServices] IProductAppService productAppService)
        {
                var createdProduct = await productAppService.UpdateAsync(request);

                return Ok(createdProduct);
        }
    }
}
