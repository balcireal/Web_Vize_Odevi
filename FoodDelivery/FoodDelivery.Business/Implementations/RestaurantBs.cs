using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.Restaurant;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace FoodDelivery.Business.Implementations
{
    public class RestaurantBs : IRestaurantBs
    {
        private readonly IRestaurantRepository _repo;
        private readonly IMapper _mapper;

        public RestaurantBs(IRestaurantRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var restaurant = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(restaurant);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

    public async Task<ApiResponse<RestaurantGetDto>> GetByIdAsync(int restaurantId, params string[] includeList)
        {
            if (restaurantId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var restaurant = await _repo.GetByIdAsync(restaurantId, includeList);
            if (restaurant != null)
            {
                var dto = _mapper.Map<RestaurantGetDto>(restaurant);
                return ApiResponse<RestaurantGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<RestaurantGetDto>>> GetRestaurantsAsync(params string[] includeList)
        {
            var restaurants = await _repo.GetAllAsync(includeList: includeList);
            if (restaurants.Count > 0)
            {
                var returnList = _mapper.Map<List<RestaurantGetDto>>(restaurants);
                var response = ApiResponse<List<RestaurantGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<RestaurantGetDto>>> GetRestaurantsByRestaurantNameAsync(string name, params string[] includeList)
        {

            var restaurants = await _repo.GetByRestaurantNameAsync(name, includeList);
            if (restaurants.Count > 0 && restaurants != null)
            {
                var returnList = _mapper.Map<List<RestaurantGetDto>>(restaurants);
                return ApiResponse<List<RestaurantGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

public async Task<ApiResponse<Restaurant>> InsertAsync(RestaurantPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek ürün bilgisi yollamalısınız");

            if (dto.RestaurantName.Length < 2)
                throw new BadRequestException("Restoran adı en az 3 harf olmalıdır");

            var restaurant = _mapper.Map<Restaurant>(dto);

            var insertedRestaurant = await _repo.InsertAsync(restaurant);
            return ApiResponse<Restaurant>.Success(StatusCodes.Status201Created, insertedRestaurant);
        }


public async Task<ApiResponse<NoData>> UpdateAsync(RestaurantPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek ürün bilgisi yollamalısınız");

            if (dto.RestaurantName.Length < 2)
                throw new BadRequestException("Restoran adı en az 3 harf olmalıdır");

            var restaurant = _mapper.Map<Restaurant>(dto);
            await _repo.UpdateAsync(restaurant);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
