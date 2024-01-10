using FoodDelivery.Model.Dtos.Country;
using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.Business.Interfaces
{
    public interface ICountryBs
    {
        Task<ApiResponse<List<CountryGetDto>>> GetCountriesAsync(params string[] includeList);
        Task<ApiResponse<List<CountryGetDto>>> GetCountriesByCountryNameAsync(string name, params string[] includeList);
        Task<ApiResponse<CountryGetDto>> GetByIdAsync(int countryId, params string[] includeList);
        Task<ApiResponse<Country>> InsertAsync(CountryPostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateAsync(CountryPutDto entity);
    }
}
