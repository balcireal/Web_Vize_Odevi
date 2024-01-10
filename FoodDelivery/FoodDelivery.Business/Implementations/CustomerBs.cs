using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.Customer;
using FoodDelivery.Model.Dtos.Product;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System.Numerics;

namespace FoodDelivery.Business.Implementations
{
    public class CustomerBs : ICustomerBs
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomerBs(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var customer = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(customer);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<CustomerGetDto>> GetByIdAsync(int customerId, params string[] includeList)
        {
            if (customerId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var customer = await _repo.GetByIdAsync(customerId, includeList);
            if (customer != null)
            {
                var dto = _mapper.Map<CustomerGetDto>(customer);
                return ApiResponse<CustomerGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomersAsync(params string[] includeList)
        {
            var customers = await _repo.GetAllAsync(includeList: includeList);
            if (customers.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);
                var response = ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByFirstNameAsync(string firstName, params string[] includeList)
        {
            if (firstName.Length < 2)
                throw new BadRequestException("Müsteri ismi en az 3 harften oluşmalıdır");

            var customers = await _repo.GetByFirstNameAsync(firstName, includeList);
            if (customers.Count > 0 && customers.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);
                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByLastNameAsync(string lastName, params string[] includeList)
        {
            if (lastName.Length < 2)
                throw new BadRequestException("Müsteri soyismi en az 3 harften oluşmalıdır");

            var customers = await _repo.GetByLastNameAsync(lastName, includeList);
            if (customers.Count > 0 && customers.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);
                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomersByPhoneAsync(string phone, params string[] includeList)
        {
            if (phone.Length <= 3)
                throw new BadRequestException("Numara en az 3 karakterden oluşmalıdır");

            var customers = await _repo.GetByPhoneAsync(phone, includeList);
            if (customers.Count > 0 && customers.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);
                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Customer>> InsertAsync(CustomerPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek müşteri bilgisi yollamalısınız");

            //if (dto.FirstName.Length < 2)
            //    throw new BadRequestException("Müsteri ismi en az 3 harften oluşmalıdır");

            //if (dto.LastName.Length < 2)
            //    throw new BadRequestException("Müsteri soyismi en az 3 harften oluşmalıdır");

            //if (dto.Phone.Length <= 3)
            //    throw new BadRequestException("Numara en az 3 karakterden oluşmalıdır");


            var customer = _mapper.Map<Customer>(dto);

            var insertedCustomer = await _repo.InsertAsync(customer);
            return ApiResponse<Customer>.Success(StatusCodes.Status201Created, insertedCustomer);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CustomerPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek müşteri bilgisi yollamalısınız");

            if (dto.FirstName.Length < 2)
                throw new BadRequestException("Müsteri ismi en az 3 harften oluşmalıdır");

            if (dto.LastName.Length < 2)
                throw new BadRequestException("Müsteri soyismi en az 3 harften oluşmalıdır");

            if (dto.Phone.Length <= 3)
                throw new BadRequestException("Numara en az 3 karakterden oluşmalıdır");

            if (dto.City.Length <= 3)
                throw new BadRequestException("Şehir adı en az 3 karakterden oluşmalıdır");

            var customer = _mapper.Map<Customer>(dto);
            await _repo.UpdateAsync(customer);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
