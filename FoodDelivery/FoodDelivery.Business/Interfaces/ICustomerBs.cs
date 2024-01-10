using FoodDelivery.Model.Dtos.Customer;
using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface ICustomerBs
    {
        Task<ApiResponse<List<CustomerGetDto>>> GetCustomersAsync(params string[] includeList);
        Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByFirstNameAsync(string firstName, params string[] includeList);
        Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByLastNameAsync(string lastName, params string[] includeList);
        Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByPhoneAsync(string phone, params string[] includeList);
        Task<ApiResponse<CustomerGetDto>> GetByIdAsync(int customerId, params string[] includeList);
        Task<ApiResponse<Customer>> InsertAsync(CustomerPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CustomerPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
