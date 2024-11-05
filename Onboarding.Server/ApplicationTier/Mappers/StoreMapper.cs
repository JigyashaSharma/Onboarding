using Onboarding.Server.ApplicationTier.Dtos;
using Onboarding.Server.Models;

namespace Onboarding.Server.ApplicationTier.Mappers
{
    public static class StoreMapper
    {
        public static Store StoreDtoToEntity(StoreDto storeDto)
        {
            return new Store
            {
                Id = storeDto.Id,
                Name = storeDto.Name,
                Location = storeDto.Location
            };
        }

        public static StoreDto EntityToStoreDto(Store store)
        {
            return new StoreDto(store);
        }
    }
}
