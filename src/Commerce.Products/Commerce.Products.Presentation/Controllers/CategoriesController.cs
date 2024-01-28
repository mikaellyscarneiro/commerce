using Commerce.Products.Application.V1.Dtos.CategoryContext.Request;
using Commerce.Products.Application.V1.Dtos.CategoryContext.Response;
using Commerce.Products.Application.V1.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Products.Presentation.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(Guid id, [FromServices] ICategoryAppService categoryAppService)
        {
                var category = await categoryAppService.GetByIdAsync(id);

                if (category == null)
                {
                    var notFoundProblem = new ProblemDetails
                    {
                        Title = "Recurso não encontrado",
                        Detail = $"Não foi possivel encontrar uma categoria com o ID: {id}",
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4"
                    };

                    return NotFound(notFoundProblem);
                }

                return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateCategoryDto request, [FromServices] ICategoryAppService categoryAppService)
        {
                var createdCategory = await categoryAppService.CreateAsync(request);

                return StatusCode(StatusCodes.Status201Created, createdCategory);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(Guid id, [FromServices] ICategoryAppService categoryAppService)
        {
                await categoryAppService.DeleteAsync(id);

                return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryDto request, [FromServices] ICategoryAppService categoryAppService)
        {
                var createdCategory = await categoryAppService.UpdateAsync(request);

                return Ok(createdCategory);
        }

    }
}
