using Onboarding.Server.ApplicationTier.Dtos;
using Onboarding.Server.ApplicationTier.Common;

namespace Onboarding.Server.ApplicationTier.Interfaces
{
    public interface ISaleMethods
    {
        public Task<PagedDtos<SaleDto>?> GetAllSalesAsync(int pageNumber, int pageSize);
        public Task<SaleDto?> GetSaleAsync(int id);

        public Task<SaleDto?> AddSaleAsync(SaleDto saleDto);

        public Task<SaleDto?> UpdateSaleAsync(int id, SaleDto saleDto);

        public Task<SaleDto> PatchSaleDetails(int id, SaleDto saleDto);
        public Task<StatusEnum> DeleteSaleAsync(int id);
        public bool SaleExists(int id);
    }
}
