using FoodDelivery.Model.Dtos.DeliveryDriver;
using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface IDeliveryDriverBs
    {
        Task<ApiResponse<List<DeliveryDriverGetDto>>> GetDeliveryDriversAsync(params string[] includeList);
        Task<ApiResponse<List<DeliveryDriverGetDto>>> GetDeliveryDriversByFirstNameAsync(string firstName, params string[] includeList);
        Task<ApiResponse<List<DeliveryDriverGetDto>>> GetDeliveryDriversByPhoneAsync(string phone, params string[] includeList);
        Task<ApiResponse<DeliveryDriverGetDto>> GetByIdAsync(int deliveryDriverId, params string[] includeList);
        Task<ApiResponse<DeliveryDriver>> InsertAsync(DeliveryDriverPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(DeliveryDriverPutDto entity);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
