using AutoMapper;
using MiniADREC.Caching.Interfaces;
using MiniADREC.Domain.Entities;
using MiniADREC.DTO.User;
using MiniADREC.Repositories.Interfaces;
using MiniADREC.Services.Interfaces;

namespace MiniADREC.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRedisCacheService _redisCache;

        public UserService(IUserRepository userRepository, IMapper mapper, IRedisCacheService redisCache)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _redisCache = redisCache;
        }

        public async Task CreateUserAsync(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            user.Roles = dto.RoleIds.Select(id => new Role { Id = id }).ToList();

            await _userRepository.AddAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
            await _redisCache.RemoveAsync("users:all");
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var cacheKey = "users:all";
            var cached = await _redisCache.GetAsync<IEnumerable<UserDto>>(cacheKey);
            if (cached != null) return cached;
            var users = await _userRepository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<UserDto>>(users);

            await _redisCache.SetAsync(cacheKey!, mapped, TimeSpan.FromMinutes(10));
            return mapped;
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task UpdateUserAsync(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            user.Roles = dto.Roles.Select(name => new Role { Name = name }).ToList();

            await _userRepository.UpdateAsync(user);

            await _redisCache.RemoveAsync("users:all");
        }
    }
}
