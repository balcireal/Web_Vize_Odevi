using AutoMapper;
using FoodDelivery.Business.CustomExceptions;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.DataAccess.Interfaces;
using FoodDelivery.Model.Dtos.AdminUser;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace FoodDelivery.Business.Implementations
{
    public class AdminUserBs : IAdminUserBs
    {
        private readonly IAdminUserRepository _repo;
        private readonly IMapper _mapper;
        public AdminUserBs(IAdminUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<ApiResponse<AdminUserGetDto>> LogIn(string userName, string password, params string[] includeList)
        {
            userName = userName.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                throw new BadRequestException("Kullanıcı Adı Boş Bırakılamaz.");
            }

            if (userName.Length <= 2)
            {
                throw new BadRequestException("Kullanıcı Adı en az 3 karakter olmalıdır.");
            }

            password = password.Trim();
            if (string.IsNullOrEmpty(password))
            {
                throw new BadRequestException("Şifre Boş Bırakılamaz.");
            }

            var adminUser = await _repo.GetByUserNameAndPasswordAsync(userName, password, includeList);

            if (adminUser != null)
            {
                var dto = _mapper.Map<AdminUserGetDto>(adminUser);
                return ApiResponse<AdminUserGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Bulunamadı.");
        }
    }
}
