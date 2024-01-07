using Commerce.Products.Application.Services.Interfaces;
using Commerce.Products.Presentation.Dtos.V1.Products.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            var dto = ProductDto.Convert(product);

            return Ok(dto);
        }
    }
}
