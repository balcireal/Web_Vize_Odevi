using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.Country;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace FoodDelivery.Business.Implementations
{
    public class CountryBs : ICountryBs
    {
        private readonly ICountryRepository _repo;
        private readonly IMapper _mapper;

        public CountryBs(ICountryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var country = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(country);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

    public async Task<ApiResponse<CountryGetDto>> GetByIdAsync(int countryId, params string[] includeList)
        {
            if (countryId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var country = await _repo.GetByIdAsync(countryId, includeList);
            if (country != null)
            {
                var dto = _mapper.Map<CountryGetDto>(country);
                return ApiResponse<CountryGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<CountryGetDto>>> GetCountriesAsync(params string[] includeList)
        {
            var countries = await _repo.GetAllAsync(includeList: includeList);
            if (countries.Count > 0)
            {
                var returnList = _mapper.Map<List<CountryGetDto>>(countries);
                var response = ApiResponse<List<CountryGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<CountryGetDto>>> GetCountriesByCountryNameAsync(string name, params string[] includeList)
        {
            if (name.Length < 2)
                throw new BadRequestException("Ülke adı en az 3 harften oluşmalıdır");

            var countries = await _repo.GetByCountryNameAsync(name, includeList);
            if (countries.Count > 0 && countries != null)
            {
                var returnList = _mapper.Map<List<CountryGetDto>>(countries);
                return ApiResponse<List<CountryGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

public async Task<ApiResponse<Country>> InsertAsync(CountryPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek ülke bilgisi yollamalısınız");

            if (dto.CountryName.Length < 2)
                throw new BadRequestException("Ülke adı en az 3 harften oluşmalıdır");

            var country = _mapper.Map<Country>(dto);

            var insertedCountry = await _repo.InsertAsync(country);
            return ApiResponse<Country>.Success(StatusCodes.Status201Created, insertedCountry);
        }

public async Task<ApiResponse<NoData>> UpdateAsync(CountryPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek ülke bilgisi yollamalısınız");
           
            if (dto.CountryId < 0)
                throw new BadRequestException("İd değeri pozifif olmalıdır");

            if (dto.CountryName.Length < 2)
                throw new BadRequestException("Ülke adı en az 3 harften oluşmalıdır");

            var country = _mapper.Map<Country>(dto);
            await _repo.UpdateAsync(country);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
