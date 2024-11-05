using Onboarding.Server.ApplicationTier.Dtos;
using Onboarding.Server.Models;

namespace Onboarding.Server.ApplicationTier.Mappers
{
    public class SaleMapper
    {
        public static SaleDto EntityToSaleDto(Sale sale)
        {
            return new SaleDto(sale);

        }

        public static Sale SaleDtoToEntity(SaleDto saleDto)
        {
            return new Sale
            {
                Id = saleDto.Id,
                CustomerId = saleDto.CustomerId,
                ProductId = saleDto.ProductId,
                StoreId = saleDto.StoreId,
                DateSold = saleDto.DateSold
            };
        }
    }
}
