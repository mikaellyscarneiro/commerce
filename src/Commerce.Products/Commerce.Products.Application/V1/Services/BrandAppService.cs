using Commerce.Products.Application.V1.Dtos.BrandContext.Request;
using Commerce.Products.Application.V1.Dtos.BrandContext.Response;
using Commerce.Products.Application.V1.Services.Interfaces;
using Commerce.Products.Domain.Models;
using Commerce.Products.Domain.Repositories.Interfaces;

namespace Commerce.Products.Application.V1.Services
{
    public class BrandAppService : IBrandAppService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandAppService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BrandDto> CreateAsync(CreateBrandDto request)
        {
            // Convertendo o DTO da controller para um objeto de domínio, evitando expor o domínio para manter a integridade do software.
            var brandToCreate = Brand.CreateNew(request.Name);

            var createdBrand = await _brandRepository.CreateAsync(brandToCreate);

            var dto = BrandDto.Convert(createdBrand) ?? throw new InvalidOperationException("Erro ao converter objeto.");

            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _brandRepository.DeleteAsync(id);
        }

        public async Task<BrandDto?> GetByIdAsync(Guid id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);

            var dto = BrandDto.Convert(brand);

            return dto;
        }

        public async Task<BrandDto> UpdateAsync(UpdateBrandDto request)
        {
            var brandFromDatabase = await _brandRepository.GetByIdAsync(request.Id);

            if (brandFromDatabase == null)
                throw new InvalidOperationException($"Não foi possível atualizar a marca, pois não foi encontrado marca com o ID: {request.Id}");

            brandFromDatabase.Update(request.Name);

            var updateBrand = await _brandRepository.UpdateAsync(brandFromDatabase);

            var dto = BrandDto.Convert(updateBrand) ?? throw new InvalidOperationException("Erro ao converter objeto.");

            return dto;
        }
    }
}
