using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.Address;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace FoodDelivery.Business.Implementations
{
    public class AddressBs : IAddressBs
    {
        private readonly IAddressRepository _repo;
        private readonly IMapper _mapper;

        public AddressBs(IAddressRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var address = await _repo.GetByIdAsync(id);

           await _repo.DeleteAsync(address);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<List<AddressGetDto>>> GetAddressesAsync(params string[] includeList)
        {
            var addresses = await _repo.GetAllAsync(includeList: includeList);
            if (addresses.Count > 0)
            {
                var returnList = _mapper.Map<List<AddressGetDto>>(addresses);
                var response = ApiResponse<List<AddressGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<AddressGetDto>>> GetAddressesByCityAsync(string city, params string[] includeList)
        {
            if (city.Length < 2)
                throw new BadRequestException("Şehir adı en az 3 harften oluşmalıdır");

            var addresses = await  _repo.GetByCityAsync(city, includeList);
            if (addresses != null && addresses.Count > 0)
            {
                var returnList = _mapper.Map<List<AddressGetDto>>(addresses);
                return ApiResponse<List<AddressGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");

        }

        public async Task<ApiResponse<List<AddressGetDto>>> GetAddressesByRegionAsync(string region, params string[] includeList)
        {
            if (region.Length < 2)
                throw new BadRequestException("Bölge adı en az 3 harften oluşmalıdır");

            var addresses = await _repo.GetByRegionAsync(region, includeList);
            if (addresses != null && addresses.Count > 0)
            {
                var returnList = _mapper.Map<List<AddressGetDto>>(addresses);
                return ApiResponse<List<AddressGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<AddressGetDto>> GetByIdAsync(int addressId, params string[] includeList)
        {
            if (addressId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var address = await _repo.GetByIdAsync(addressId, includeList);
            if (address != null)
            {
                var dto = _mapper.Map<AddressGetDto>(address);
                return ApiResponse<AddressGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Address>> InsertAsync(AddressPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek adres bilgisi yollamalısınız");

            if (dto.City.Length < 2)
                throw new BadRequestException("Şehir adı en az 3 harften oluşmalıdır\"");


            var address = _mapper.Map<Address>(dto);

            var insertedAddress = await _repo.InsertAsync(address);
            return ApiResponse<Address>.Success(StatusCodes.Status201Created, insertedAddress);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(AddressPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek adres bilgisi yollamalısınız");

            if (dto.PostalCode.Length == 5 )
                throw new BadRequestException("Posta kodu 5 karakter olmalıdır");

            var address = _mapper.Map<Address>(dto);

           await _repo.UpdateAsync(address);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
