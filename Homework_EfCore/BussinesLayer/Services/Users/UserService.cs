using AutoMapper;
using AutoMapper.QueryableExtensions;
using BussinesLayer.Dtos;
using BussinesLayer.Interfaces;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Users
{
    public sealed class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyCollection<UserResponseDto>> GetAll()
        {
            return await _userRepository.GetAll()
                                        .ProjectTo<UserResponseDto>(_mapper.ConfigurationProvider)
                                        .ToArrayAsync();
        }

        public async Task<UserResponseDto> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<UserResponseDto>(user);
        }

        public Task<UserResponseDto> Add(UserRequestDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDto> Update(Guid id, UserRequestDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
