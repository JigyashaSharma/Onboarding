using Onboarding.Server.ApplicationTier.Dtos;
using Onboarding.Server.Models;

namespace Onboarding.Server.ApplicationTier.Mappers
{
    public class CustomerMapper
    {
        public static Customer CustomerDtoToEntity(CustomerDto customerDto)
        {
            var entity = new Customer
            {
                Id = customerDto.Id,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                DateOfBirth = customerDto.DateOfBirth
            };

            return entity;
        }

        public static CustomerDto EntityToCustomerDto(Customer customer)
        {
            var dto = new CustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth
            };
            return dto;
        }
    }
}
