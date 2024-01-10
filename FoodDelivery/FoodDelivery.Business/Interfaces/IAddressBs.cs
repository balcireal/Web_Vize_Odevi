using FoodDelivery.Model.Dtos.Address;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface IAddressBs
    {
        Task<ApiResponse<List<AddressGetDto>>> GetAddressesAsync(params string[] includeList);
        Task<ApiResponse<List<AddressGetDto>>> GetAddressesByRegionAsync(string region, params string[] includeList);
        Task<ApiResponse<List<AddressGetDto>>> GetAddressesByCityAsync(string city, params string[] includeList);
        Task<ApiResponse<AddressGetDto>> GetByIdAsync(int addressId, params string[] includeList);
        Task<ApiResponse<Address>> InsertAsync(AddressPostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(AddressPutDto entity);
    }
}
