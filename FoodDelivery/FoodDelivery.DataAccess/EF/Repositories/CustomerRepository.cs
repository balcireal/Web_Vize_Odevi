using FoodDelivery.DataAccess.EF.Contexts;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace FoodDelivery.DataAccess.EF.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, FoodDeliveryDbContext>, ICustomerRepository
    {
        public async Task<List<Customer>> GetByFirstNameAsync(string firstName, params string[] includeList)
        {
            return await GetAllAsync(cust => cust.FirstName.Contains(firstName), includeList);
        }

        public async Task<Customer> GetByIdAsync(int customerId, params string[] includeList)
        {
            return await GetAsync(cust => cust.CustomerId == customerId, includeList);
        }

        public async Task<List<Customer>> GetByLastNameAsync(string lastName, params string[] includeList)
        {
            return await GetAllAsync(cust => cust.LastName.Contains(lastName), includeList);
        }

        public async Task<List<Customer>> GetByPhoneAsync(string phone, params string[] includeList)
        {
            return await GetAllAsync(cust => cust.Phone.Contains(phone), includeList);
        }
    }
}
