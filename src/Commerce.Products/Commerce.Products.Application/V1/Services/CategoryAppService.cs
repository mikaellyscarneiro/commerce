using Commerce.Products.Application.V1.Dtos.CategoryContext.Request;
using Commerce.Products.Application.V1.Dtos.CategoryContext.Response;
using Commerce.Products.Application.V1.Services.Interfaces;
using Commerce.Products.Domain.Models;
using Commerce.Products.Domain.Repositories.Interfaces;

namespace Commerce.Products.Application.V1.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAppService(ICategoryRepository  categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto request)
        {
            // Convertendo o DTO da controller para um objeto de domínio, evitando expor o domínio para manter a integridade do software.
            var categoryToCreate = Category.CreateNew(request.Name);

            var createdCategory = await _categoryRepository.CreateAsync(categoryToCreate);

            var dto = CategoryDto.Convert(createdCategory) ?? throw new InvalidOperationException("Erro ao converter objeto.");

            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            var dto = CategoryDto.Convert(category);

            return dto;
        }

        public async Task<CategoryDto> UpdateAsync(UpdateCategoryDto request)
        {
            var categoryFromDatabase = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryFromDatabase == null)
                throw new InvalidOperationException($"Não foi possível atualizar a categoria, pois não foi encontrado categoria com o ID: {request.Id}");

            categoryFromDatabase.Update(request.Name);

            var updateCategory = await _categoryRepository.UpdateAsync(categoryFromDatabase);

            var dto = CategoryDto.Convert(updateCategory) ?? throw new InvalidOperationException("Erro ao converter objeto.");

            return dto;
        }
    }
}
