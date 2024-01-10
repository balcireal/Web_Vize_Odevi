using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<List<Country>> GetByCountryNameAsync(string name, params string[] includeList);

        Task<Country> GetByIdAsync(int countryId, params string[] includeList);
    }
}
