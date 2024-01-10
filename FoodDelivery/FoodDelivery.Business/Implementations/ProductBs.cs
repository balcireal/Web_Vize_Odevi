using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace FoodDelivery.Business.Implementations
{
    public class ProductBs : IProductBs
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductBs(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var product = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(product);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<ProductGetDto>> GetByIdAsync(int productId, params string[] includeList)
        {
            if (productId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var product = await _repo.GetByIdAsync(productId, includeList);
            if (product != null)
            {
                var dto = _mapper.Map<ProductGetDto>(product);
                return ApiResponse<ProductGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetProductsAsync(params string[] includeList)
        {
            var products = await _repo.GetAllAsync(includeList: includeList);

            if (products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);
                var response = ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetProductsByPriceRangeAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("min,max'tan büyük olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("max ve min değerleri pozitif olmalıdır");

            if (min == max)
                throw new BadRequestException("min ve max birbirinden farklı olmalıdır");

            var products = await _repo.GetByPriceRangeAsync(min, max, includeList);

            if (products != null && products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetProductsByProductNameAsync(string productName, params string[] includeList)
        {
            if (productName.Length <= 3)
                throw new BadRequestException("Ürün adı en az 3 harften oluşmalıdır");

            var products = await _repo.GetByProductNameAsync(productName, includeList);
            if (products.Count > 0)
            {
                var returnList = _mapper.Map<List<ProductGetDto>>(products);
                return ApiResponse<List<ProductGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Product>> InsertAsync(ProductPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek ürün bilgisi yollamalısınız");

            if (dto.ProductName.Length <= 3)
                throw new BadRequestException("Ürün adı en az 3 harften oluşmalıdır");

            if (dto.Price <= 0)
                throw new BadRequestException("Fiyat 0 dan büyük olmalıdır");

            if (dto.CategoryId <= 0)
                throw new BadRequestException("Id dan büyük olmalıdır");

            if (dto.RestaurantName.Length <= 3)
                throw new BadRequestException("Restoran adı en az 3 harf olmalıdır");

            if (dto.QtyOrdered <= 0)
                throw new BadRequestException("Sipariş adedi 0 dan büyük olmalıdır");


            var product = _mapper.Map<Product>(dto);

            var insertedProduct = await _repo.InsertAsync(product);
            return ApiResponse<Product>.Success(StatusCodes.Status201Created, insertedProduct);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek ürün bilgisi yollamalısınız");

            if (dto.ProductId <= 0)
                throw new BadRequestException("Id 0 dan büyük olmalıdır");

            if (dto.ProductName.Length <= 3)
                throw new BadRequestException("Ürün adı en az 3 harften oluşmalıdır");

            if (dto.Price <= 0)
                throw new BadRequestException("Fiyat 0 dan büyük olmalıdır");

            var product = _mapper.Map<Product>(dto);
            await _repo.UpdateAsync(product);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
