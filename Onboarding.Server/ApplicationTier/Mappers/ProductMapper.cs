using Onboarding.Server.ApplicationTier.Dtos;
using Onboarding.Server.Models;

namespace Onboarding.Server.ApplicationTier.Mappers
{
    public static class ProductMapper
    {
        public static Product ProductDtoToEntity(ProductDto productDto)
        {
            var entity = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Active = productDto.Active,
                Price = productDto.Price
            };

            return entity;
        }

        public static ProductDto EntityToProductDto(Product product)
        {
            var dto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Active = product.Active,
                Price = product.Price
            };

            return dto;
        }
    }
}
