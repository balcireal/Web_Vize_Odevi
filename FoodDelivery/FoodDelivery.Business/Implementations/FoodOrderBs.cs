using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.FoodOrder;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace FoodDelivery.Business.Implementations
{
    public class FoodOrderBs : IFoodOrderBs
    {
        private readonly IFoodOrderRepository _repo;
        private readonly IMapper _mapper;

        public FoodOrderBs(IFoodOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var foodOrder = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(foodOrder);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<FoodOrderGetDto>> GetByIdAsync(int foodOrderId, params string[] includeList)
        {
            if (foodOrderId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var foodOrder = await _repo.GetByIdAsync(foodOrderId, includeList);
            if (foodOrder != null)
            {
                var dto = _mapper.Map<FoodOrderGetDto>(foodOrder);
                return ApiResponse<FoodOrderGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<FoodOrderGetDto>>> GetFoodOrdersAsync(params string[] includeList)
        {
            var foodOrders = await _repo.GetAllAsync(includeList: includeList);
            if (foodOrders.Count > 0)
            {
                var returnList = _mapper.Map<List<FoodOrderGetDto>>(foodOrders);
                var response = ApiResponse<List<FoodOrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<FoodOrderGetDto>>> GetFoodOrdersByDeliveryFeeAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("min,max'tan büyük olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("max ve min değerleri pozitif olmalıdır");


            var foodOrders = await _repo.GetByDeliveryFeeAsync(min, max, includeList);
            if (foodOrders.Count > 0 && foodOrders != null)
            {
                var returnList = _mapper.Map<List<FoodOrderGetDto>>(foodOrders);
                return ApiResponse<List<FoodOrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<FoodOrderGetDto>>> GetFoodOrdersByTotalAmountAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("min,max'tan büyük olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("max ve min değerleri pozitif olmalıdır");


            var foodOrders = await _repo.GetByTotalAmountAsync(min, max, includeList);
            if (foodOrders.Count > 0 && foodOrders != null)
            {
                var returnList = _mapper.Map<List<FoodOrderGetDto>>(foodOrders);
                return ApiResponse<List<FoodOrderGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<FoodOrder>> InsertAsync(FoodOrderPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek ürün bilgisi yollamalısınız");

            if (dto.TotalAmount <= 0)
                throw new BadRequestException("Ürün tutarı pozitif olmalıdır");

            if (dto.DeliveryFee <= 0)
                throw new BadRequestException("Teslimat ücreti pozitif olmalıdır");

            var foodOrder = _mapper.Map<FoodOrder>(dto);
            var insertedFoodOrder = await _repo.InsertAsync(foodOrder);
            return ApiResponse<FoodOrder>.Success(StatusCodes.Status201Created, insertedFoodOrder);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(FoodOrderPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek ürün bilgisi yollamalısınız");

            if (dto.FoodOrderId < 0)
                throw new BadRequestException("Id pozitif olmalıdır");

            if (dto.TotalAmount <= 0)
                throw new BadRequestException("Ürün tutarı pozitif olmalıdır");

            if (dto.DeliveryFee <= 0)
                throw new BadRequestException("Teslimat ücreti pozitif olmalıdır");

            var foodOrder = _mapper.Map<FoodOrder>(dto);
            await _repo.UpdateAsync(foodOrder);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
