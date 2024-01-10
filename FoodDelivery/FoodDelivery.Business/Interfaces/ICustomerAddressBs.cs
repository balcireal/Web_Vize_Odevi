using FoodDelivery.Model.Dtos.CustomerAddress;
using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface ICustomerAddressBs
    {
        Task<ApiResponse<List<CustomerAddressGetDto>>> GetCustomerAddressesAsync(params string[] includeList);
        Task<ApiResponse<CustomerAddressGetDto>> GetByIdAsync(int customerAddressId, params string[] includeList);
        Task<ApiResponse<CustomerAddress>> InsertAsync(CustomerAddressPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CustomerAddressPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);

    }
}
