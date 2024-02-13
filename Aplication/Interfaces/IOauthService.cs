using Aplication.Base;
using Aplication.Dtos;
using Aplication.Mappers;
using WebApi.Commons;

namespace Aplication.Interfaces
{
    public interface IOauthService
    {
        Task<Response<TokenClaims>> Refresh(Guid id);
        Task<Response<TokenClaims>> Token(TokenRequest id);
    }
}
