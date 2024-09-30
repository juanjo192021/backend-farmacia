using api_fameza.Dtos;
using api_fameza.Models;
using api_fameza.Models.Request;
using api_fameza.Models.Responses;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_fameza.Security.Implementation
{
    public class AuthService : IAuthService
    {

        private readonly DbFarmaciaContext _dbcontext;
        private readonly IMapper _mapper;

        public AuthService(DbFarmaciaContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        DataResponse<UserDto> dataResponseUser = new DataResponse<UserDto>();

        public async Task<DataResponse<UserDto>> findByEmail(AuthRequest authRequest)
        {
            User user = _dbcontext.Users.Include(x => x.Role).FirstOrDefault(x => x.Email == authRequest.Email && x.Password ==authRequest.Password);

            if (user == null)
            {
                dataResponseUser.StatusCode = 404;
                dataResponseUser.Error = "Not Found";
                dataResponseUser.Message = "Usuario no encontrado";
                dataResponseUser.Success = false;

                return dataResponseUser;
            }

            if (user.Status == false)
            {
                dataResponseUser.StatusCode = 401;
                dataResponseUser.Error = "Unauthorized";
                dataResponseUser.Message = "Usuario sin autorización de acceso";
                dataResponseUser.Success = false;
                dataResponseUser.Data = _mapper.Map<UserDto>(user);

                return dataResponseUser;
            }

            dataResponseUser.StatusCode = 200;
            dataResponseUser.Message = "OK";
            dataResponseUser.Success = true;
            dataResponseUser.Data = _mapper.Map<UserDto>(user);

            return dataResponseUser;
        }
    }
}
