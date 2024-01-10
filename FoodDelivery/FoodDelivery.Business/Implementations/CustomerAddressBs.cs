using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.CustomerAddress;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace FoodDelivery.Business.Implementations
{
    public class CustomerAddressBs : ICustomerAddressBs
    {
        private readonly ICustomerAddressRepository _repo;
        private readonly IMapper _mapper;

        public CustomerAddressBs(ICustomerAddressRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var customerAddress = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(customerAddress);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<CustomerAddressGetDto>> GetByIdAsync(int customerAddressId, params string[] includeList)
        {
            if (customerAddressId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var customerAddress = await _repo.GetByIdAsync(customerAddressId, includeList);
            if (customerAddress != null)
            {
                var dto = _mapper.Map<CustomerAddressGetDto>(customerAddress);
                return ApiResponse<CustomerAddressGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<CustomerAddressGetDto>>> GetCustomerAddressesAsync(params string[] includeList)
        {
            var customerAddresses = await _repo.GetAllAsync(includeList: includeList);
            if (customerAddresses.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerAddressGetDto>>(customerAddresses);
                var response = ApiResponse<List<CustomerAddressGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<CustomerAddress>> InsertAsync(CustomerAddressPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek müşteri adresi bilgisi yollamalısınız");

            if (dto.FullAddress.Length <= 5)
                throw new BadRequestException("Adres minimum 5 karakter olmalıdır");

            if (dto.FirstName.Length <= 3)
                throw new BadRequestException("İsim minimum 3 karakter olmalıdır");

            var customerAddress = _mapper.Map<CustomerAddress>(dto);
            var insertedCustomerAddress = await _repo.InsertAsync(customerAddress);
            return ApiResponse<CustomerAddress>.Success(StatusCodes.Status201Created, insertedCustomerAddress);

        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CustomerAddressPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek müşteri adresi bilgisi yollamalısınız");

            if (dto.CustomerAddressId <= 0)
                throw new BadRequestException("Id 0 dan büyük olmalıdır");

            if (dto.AddressId <= 0)
                throw new BadRequestException("Id 0 dan büyük olmalıdır");

            if (dto.CustomerId <= 0)
                throw new BadRequestException("Id 0 dan büyük olmalıdır");

            var customerAddress = _mapper.Map<CustomerAddress>(dto);
            await _repo.UpdateAsync(customerAddress);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
