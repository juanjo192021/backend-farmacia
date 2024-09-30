using api_fameza.Models.Request;
using api_fameza.Models.Responses;
using api_fameza.Dtos;

namespace api_fameza.Security
{
    public interface IAuthService
    {
        public Task<DataResponse<UserDto>> findByEmail(AuthRequest authRequest);
    }
}
