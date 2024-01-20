using Commerce.Products.Application.V1.Dtos.BrandContext.Request;
using Commerce.Products.Application.V1.Dtos.BrandContext.Response;
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

        [HttpPost]
        [ProducesResponseType(typeof(BrandDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateBrandDto request, [FromServices] IBrandAppService brandAppService)
        {
                var createdBrand = await brandAppService.CreateAsync(request);

                return StatusCode(StatusCodes.Status201Created, createdBrand);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] IBrandAppService brandAppService)
        {
                await brandAppService.DeleteAsync(id);

                return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(typeof(BrandDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateBrandDto request, [FromServices] IBrandAppService brandAppService)
        {
                var createdBrand = await brandAppService.UpdateAsync(request);

                return Ok(createdBrand);
        }
    }
}
