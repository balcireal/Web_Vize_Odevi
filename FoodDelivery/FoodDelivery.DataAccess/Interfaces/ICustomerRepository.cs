using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<List<Customer>> GetByFirstNameAsync(string firstName, params string[] includeList);
        Task<List<Customer>> GetByLastNameAsync(string lastName, params string[] includeList);
        Task<List<Customer>> GetByPhoneAsync(string phone, params string[] includeList);
        Task<Customer> GetByIdAsync(int customerId, params string[] includeList);
    }
}
