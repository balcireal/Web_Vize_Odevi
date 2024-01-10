using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.DeliveryDriver;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace FoodDelivery.Business.Implementations
{
    public class DeliveryDriverBs : IDeliveryDriverBs
    {
        private readonly IDeliveryDriverRepository _repo;
        private readonly IMapper _mapper;

        public DeliveryDriverBs(IDeliveryDriverRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var deliveryDriver = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(deliveryDriver);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<DeliveryDriverGetDto>> GetByIdAsync(int deliveryDriverId, params string[] includeList)
        {
            if (deliveryDriverId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var deliveryDriver = await _repo.GetByIdAsync(deliveryDriverId, includeList);
            if (deliveryDriver != null)
            {
                var dto = _mapper.Map<DeliveryDriverGetDto>(deliveryDriver);
                return ApiResponse<DeliveryDriverGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<DeliveryDriverGetDto>>> GetDeliveryDriversAsync(params string[] includeList)
        {
            var deliveryDrivers = await _repo.GetAllAsync(includeList: includeList);
            if (deliveryDrivers.Count > 0)
            {
                var returnList = _mapper.Map<List<DeliveryDriverGetDto>>(deliveryDrivers);
                var response = ApiResponse<List<DeliveryDriverGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<DeliveryDriverGetDto>>> GetDeliveryDriversByFirstNameAsync(string firstName, params string[] includeList)
        {
            if (firstName.Length < 2)
                throw new BadRequestException("İsim en az 3 harften oluşmalıdır");

            var deliveryDrivers = await _repo.GetByFirstNameAsync(firstName, includeList);
            if (deliveryDrivers.Count > 0 && deliveryDrivers != null)
            {
                var returnList = _mapper.Map<List<DeliveryDriverGetDto>>(deliveryDrivers);
                return ApiResponse<List<DeliveryDriverGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<DeliveryDriverGetDto>>> GetDeliveryDriversByPhoneAsync(string phone, params string[] includeList)
        {
            if (phone.Length <= 3)
                throw new BadRequestException("Telefon numarası en az 3 karakterden oluşmalıdır");

            var deliveryDrivers = await _repo.GetByPhoneAsync(phone, includeList);
            if (deliveryDrivers.Count > 0 && deliveryDrivers != null)
            {
                var returnList = _mapper.Map<List<DeliveryDriverGetDto>>(deliveryDrivers);
                return ApiResponse<List<DeliveryDriverGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<DeliveryDriver>> InsertAsync(DeliveryDriverPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek ürün bilgisi yollamalısınız");

            if (dto.FirstName.Length < 2)
                throw new BadRequestException("İsim en az 3 harften oluşmalıdır");

            if (dto.LastName.Length < 2)
                throw new BadRequestException("Soyisim en az 3 harften oluşmalıdır");

            if (dto.Phone.Length <= 3)
                throw new BadRequestException("Telefon numarası en az 3 karakterden oluşmalıdır");

            var deliveryDriver = _mapper.Map<DeliveryDriver>(dto);

            var insertedDeliveryDriver = await _repo.InsertAsync(deliveryDriver);
            return ApiResponse<DeliveryDriver>.Success(StatusCodes.Status201Created, insertedDeliveryDriver);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(DeliveryDriverPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek kurye bilgisi yollamalısınız");

            if (dto.FirstName.Length < 2)
                throw new BadRequestException("İsim en az 3 harften oluşmalıdır");

            if (dto.LastName.Length < 2)
                throw new BadRequestException("Soyisim en az 3 harften oluşmalıdır");

            if (dto.Phone.Length <= 3)
                throw new BadRequestException("Telefon numarası en az 3 karakterden oluşmalıdır");

            var deliveryDriver = _mapper.Map<DeliveryDriver>(dto);
            await _repo.UpdateAsync(deliveryDriver);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
