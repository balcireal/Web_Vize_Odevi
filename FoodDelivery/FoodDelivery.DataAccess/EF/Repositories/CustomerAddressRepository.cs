using FoodDelivery.DataAccess.EF.Contexts;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace FoodDelivery.DataAccess.EF.Repositories
{
    public class CustomerAddressRepository : BaseRepository<CustomerAddress, FoodDeliveryDbContext>, ICustomerAddressRepository
    {
        public async Task<CustomerAddress> GetByIdAsync(int customerAddressId, params string[] includeList)
        {
            return await GetAsync(cadr => cadr.CustomerAddressId== customerAddressId, includeList);
        }
    }
}
