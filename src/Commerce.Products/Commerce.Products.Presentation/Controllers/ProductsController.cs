using Commerce.Products.Application.V1.Dtos.Products.Request;
using Commerce.Products.Application.V1.Services.Interfaces;
using Commerce.Products.Presentation.Dtos.V1.Products.Request;
using Commerce.Products.Presentation.Dtos.V1.Products.Response;
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
            try
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
            catch (InvalidOperationException ex)
            {
                return ConvertToProblem(ex);
            }
            catch (Exception)
            {
                return ConvertToProblemInternalServerError();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateProductDto request, [FromServices] IProductAppService productAppService)
        {
            try
            {
                var createdProduct = await productAppService.CreateAsync(request);

                return StatusCode(StatusCodes.Status201Created, createdProduct);
            }
            catch (InvalidOperationException ex)
            {
                return ConvertToProblem(ex);
            }
            catch (Exception)
            {
                return ConvertToProblemInternalServerError();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] IProductAppService productAppService)
        {
            try
            {
                await productAppService.DeleteAsync(id);

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return ConvertToProblem(ex);
            }
            catch (Exception)
            {
                return ConvertToProblemInternalServerError();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateProductDto request, [FromServices] IProductAppService productAppService)
        {
            try
            {
                var createdProduct = await productAppService.UpdateAsync(request);

                return Ok(createdProduct);
            }
            catch (InvalidOperationException ex)
            {
                return ConvertToProblem(ex);
            }
            catch (Exception)
            {
                return ConvertToProblemInternalServerError();
            }
        }

        private IActionResult ConvertToProblem(InvalidOperationException exception)
        {
            var problem = new ProblemDetails
            {
                Title = "Requisição inválida",
                Detail = exception.Message,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4"
            };

            return BadRequest(problem);
        }

        private IActionResult ConvertToProblemInternalServerError()
        {
            var problem = new ProblemDetails
            {
                Title = "Erro interno",
                Detail = "Ocorreu um erro interno no servidor.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            return StatusCode(StatusCodes.Status500InternalServerError, problem);
        }
    }
}
