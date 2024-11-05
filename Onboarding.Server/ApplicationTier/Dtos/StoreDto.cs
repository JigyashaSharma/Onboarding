using Onboarding.Server.Models;

namespace Onboarding.Server.ApplicationTier.Dtos
{
    public class StoreDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Location { get; set; }

        public decimal? TotalSale { get;}

        //Needed for the creation of StoreDto object for the controller request
        public StoreDto() { }
        public StoreDto(Store store) 
        {
            Id = store.Id;
            Name = store.Name;
            Location = store.Location;
            TotalSale = store.Sales?.Sum(p => p.Product.Price);
        }
    }
}
