using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.OrderProduct;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace FoodDelivery.Business.Implementations
{
    public class OrderProductBs : IOrderProductBs
    {
        private readonly IOrderProductRepository _repo;
        private readonly IMapper _mapper;
        public OrderProductBs(IOrderProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var orderProduct = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(orderProduct);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<OrderProductGetDto>> GetByIdAsync(int orderProductId, params string[] includeList)
        {
            var orderProduct = await _repo.GetByIdAsync(orderProductId, includeList);
            if (orderProduct != null)
            {
                var dto = _mapper.Map<OrderProductGetDto>(orderProduct);
                return ApiResponse<OrderProductGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<OrderProductGetDto>>> GetOrderProductsAsync(params string[] includeList)
        {
            var orderProducts = await _repo.GetAllAsync(includeList: includeList);
            if (orderProducts.Count > 0)
            {
                var returnList = _mapper.Map<List<OrderProductGetDto>>(orderProducts);
                var response = ApiResponse<List<OrderProductGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<OrderProductGetDto>>> GetOrderProductsByQtyOrderedAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("min,max'tan büyük olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("max ve min değerleri pozitif olmalıdır");

            var orderProducts = await _repo.GetByQtyOrderedAsync(min, max, includeList);
            if (orderProducts.Count > 0 && orderProducts != null)
            {
                var returnList = _mapper.Map<List<OrderProductGetDto>>(orderProducts);
                return ApiResponse<List<OrderProductGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<OrderProduct>> InsertAsync(OrderProductPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek ürün siparişi bilgisi yollamalısınız");

            if (dto.QtyOrdered <= 0)
                throw new BadRequestException("Sipariş miktarı pozitif olmalıdır");
            if (dto.ProductName.Length < 2)
                throw new BadRequestException("Ürün adı minimum 3 harften oluşmalıdır");

            var orderProduct = _mapper.Map<OrderProduct>(dto);

            var insertedOrderProduct = await _repo.InsertAsync(orderProduct);
            return ApiResponse<OrderProduct>.Success(StatusCodes.Status201Created, insertedOrderProduct);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(OrderProductPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek ürün bilgisi yollamalısınız");

            if (dto.QtyOrdered <= 0)
                throw new BadRequestException("Sipariş miktarı pozitif olmalıdır");

            var orderProduct = _mapper.Map<OrderProduct>(dto);
            await _repo.UpdateAsync(orderProduct);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
