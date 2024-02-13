using Aplication.Base;
using Aplication.Dtos;
using Aplication.Interfaces;
using Aplication.Mappers;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using WebApi.Commons;

namespace Aplication.Contracts
{
    public class OauthService : IOauthService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public OauthService(IUserRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;   
        }
        public async Task<Response<TokenClaims>> Refresh(Guid id)
        {
            var response = await _repository.GetByIdAsync(id);
            if(response == null)
            {
                throw new NoContentException($"No User found.");
            }
            return new Response<TokenClaims>(_mapper.Map<User,TokenClaims>(response));
        }

        public async Task<Response<TokenClaims>> Token(TokenRequest user)
        {
            var response = await _repository.GetAsync(x => x.Password == user.Password && user.UserName == x.UserName);
            if (response.FirstOrDefault() == null)
            {
                throw new NoContentException($"No User found.");
            }
            return new Response<TokenClaims>(_mapper.Map<TokenClaims>(response.FirstOrDefault()));
        }
    }
}
