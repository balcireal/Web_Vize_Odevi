using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.OrderStatus;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace FoodDelivery.Business.Implementations
{
    public class OrderStatusBs : IOrderStatusBs
    {
        private readonly IOrderStatusRepository _repo;
        private readonly IMapper _mapper;

        public OrderStatusBs(IOrderStatusRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var orderStatus = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(orderStatus);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<OrderStatusGetDto>> GetByIdAsync(int orderStatusId, params string[] includeList)
        {
            if (orderStatusId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var orderStatus = await _repo.GetByIdAsync(orderStatusId, includeList);
            if (orderStatus != null)
            {
                var dto = _mapper.Map<OrderStatusGetDto>(orderStatus);
                return ApiResponse<OrderStatusGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<OrderStatusGetDto>>> GetOrderStatusesAsync(params string[] includeList)
        {
            var orderStatuses = await _repo.GetAllAsync(includeList: includeList);
            if (orderStatuses.Count > 0)
            {
                var returnList = _mapper.Map<List<OrderStatusGetDto>>(orderStatuses);
                var response = ApiResponse<List<OrderStatusGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<OrderStatusGetDto>>> GetOrderStatusesByStatusValueAsync(string status, params string[] includeList)
        {
            if (status.Length < 9)
                throw new BadRequestException("Sipariş durumu minimum 9 karakter olmalıdır");

            var orderStatuses = await _repo.GetByStatusValueAsync(status, includeList);
            if (orderStatuses.Count > 0 && orderStatuses != null)
            {
                var returnList = _mapper.Map<List<OrderStatusGetDto>>(orderStatuses);
                return ApiResponse<List<OrderStatusGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<OrderStatus>> InsertAsync(OrderStatusPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek durum bilgisi yollamalısınız");

            if (dto.StatusValue.Length < 10)
                throw new BadRequestException("Sipariş durumu minimum 9 karakter olmalıdır");

            var orderStatus = _mapper.Map<OrderStatus>(dto);
            var insertedOrderStatus = await _repo.InsertAsync(orderStatus);
            return ApiResponse<OrderStatus>.Success(StatusCodes.Status201Created, insertedOrderStatus);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(OrderStatusPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek durum bilgisi yollamalısınız");

            if (dto.OrderStatusId < 0)
                throw new BadRequestException("id değeri pozitif olmalıdır");

            if (dto.StatusValue.Length < 10)
                throw new BadRequestException("Sipariş durumu minimum 9 karakter olmalıdır");

            var orderStatus = _mapper.Map<OrderStatus>(dto);
            await _repo.UpdateAsync(orderStatus);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
