using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.Category;
using FoodDelivery.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace FoodDelivery.Business.Implementations
{
    public class CategoryBs : ICategoryBs
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryBs(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var category = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(category);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int categoryId, params string[] includeList)
        {
            if (categoryId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var category = await _repo.GetByIdAsync(categoryId, includeList);
            if (category != null)
            {
                var dto = _mapper.Map<CategoryGetDto>(category);
                return ApiResponse<CategoryGetDto>.Success(StatusCodes.Status200OK, dto);
            }

            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesAsync(params string[] includeList)
        {
            var categories = await _repo.GetAllAsync(includeList: includeList);
            if (categories.Count > 0)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(categories);
                var response = ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByCategoryNameAsync(string name, params string[] includeList)
        {
            if (name.Length < 2)
                throw new BadRequestException("Kategori adı en az 3 harften oluşmalıdır");

            var categories = await _repo.GetByCategoryNameAsync(name, includeList);
            if (categories.Count > 0 && categories != null)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(categories);
                return ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");

        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetCategoriesByDescriptionAsync(string description, params string[] includeList)
        {
            if (description.Length <= 3)
                throw new BadRequestException("Açıklama minimum 3 harften oluşmalıdır");

            var categories = await _repo.GetByDescriptionAsync(description, includeList);
            if (categories.Count > 0 && categories != null)
            {
                var returnList = _mapper.Map<List<CategoryGetDto>>(categories);
                return ApiResponse<List<CategoryGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        //public async Task<ApiResponse<Category>> InsertAsync(CategoryPostDto dto)
        //{
        //    if (dto == null)
        //        throw new BadRequestException("Kaydedilecek kategori bilgisi yollamalısınız");


        //    if (dto.CategoryName.Length < 2)
        //        throw new BadRequestException("Kategori adı en az 3 harften oluşmalıdır");

        //    if (dto.Description.Length <= 10)
        //        throw new BadRequestException("Açıklama minimum 10 harften oluşmalıdır");

        //    var category = _mapper.Map<Category>(dto);

        //    var insertedCategory = await _repo.InsertAsync(category);
        //    return ApiResponse<Category>.Success(StatusCodes.Status201Created, insertedCategory);
        //}

        public async Task<ApiResponse<CategoryGetDto>> InsertAsync(CategoryPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek kategori bilgisi yollamalısınız");


            if (dto.CategoryName.Length < 2)
                throw new BadRequestException("Kategori adı en az 3 harften oluşmalıdır");

            if (dto.Description.Length <= 10)
                throw new BadRequestException("Açıklama minimum 10 harften oluşmalıdır");

            var category = _mapper.Map<Category>(dto);

            var insertedCategory = await _repo.InsertAsync(category);

            var retCat = _mapper.Map<CategoryGetDto>(insertedCategory);
            return ApiResponse<CategoryGetDto>.Success(StatusCodes.Status201Created, retCat);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Güncellenecek kategori bilgisi yollamalısınız");

            if (dto.CategoryName.Length < 2)
                throw new BadRequestException("Kategori adı en az 3 harften oluşmalıdır");

            var category = _mapper.Map<Category>(dto);
            await _repo.InsertAsync(category);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
