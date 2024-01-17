using Commerce.Products.Application.V1.Dtos.BrandContext.Request;
using Commerce.Products.Application.V1.Dtos.BrandContext.Response;
using Commerce.Products.Application.V1.Dtos.CategoryContext.Request;
using Commerce.Products.Application.V1.Dtos.ProductContext.Request;
using Commerce.Products.Application.V1.Services;
using Commerce.Products.Application.V1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Products.Presentation.Controllers
{
    [ApiController]
    [Route("brands")]
    public class BrandsController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BrandDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, [FromServices] IBrandAppService brandAppService)
        {
            try
            {
                var brand = await brandAppService.GetByIdAsync(id);

                if (brand == null)
                {
                    var notFoundProblem = new ProblemDetails
                    {
                        Title = "Recurso não encontrado",
                        Detail = $"Não foi possivel encontrar uma marca com o ID: {id}",
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4"
                    };

                    return NotFound(notFoundProblem);
                }

                return Ok(brand);
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
        [ProducesResponseType(typeof(BrandDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateBrandDto request, [FromServices] IBrandAppService brandAppService)
        {
            try
            {
                var createdBrand = await brandAppService.CreateAsync(request);

                return StatusCode(StatusCodes.Status201Created, createdBrand);
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
        public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] IBrandAppService brandAppService)
        {
            try
            {
                await brandAppService.DeleteAsync(id);

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
        [ProducesResponseType(typeof(BrandDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateBrandDto request, [FromServices] IBrandAppService brandAppService)
        {
            try
            {
                var createdBrand = await brandAppService.UpdateAsync(request);

                return Ok(createdBrand);
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
