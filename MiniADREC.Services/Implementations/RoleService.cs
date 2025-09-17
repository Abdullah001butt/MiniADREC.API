using MiniADREC.Caching.Interfaces;
using MiniADREC.Domain.Entities;
using MiniADREC.Repositories.Interfaces;
using MiniADREC.Services.Interfaces;

namespace MiniADREC.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRedisCacheService _redisCache;

        private const string CacheKey = "roles:all";

        public RoleService(IRoleRepository roleRepository, IRedisCacheService redisCache)
        {
            _roleRepository = roleRepository;
            _redisCache = redisCache;
        }

        public async Task CreateRoleAsync(Role role)
        {
            await _roleRepository.AddAsync(role);
            await _redisCache.RemoveAsync(CacheKey);
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteAsync(id);
            await _redisCache.RemoveAsync(CacheKey);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            var cached = await _redisCache.GetAsync<IEnumerable<Role>>(CacheKey);
            if (cached != null) return cached;

            var roles = await _roleRepository.GetAllAsync();
            await _redisCache.SetAsync(CacheKey, roles, TimeSpan.FromHours(1));
            return roles;
        }

        public async Task<Role?> GetRoleByIdAsync(int id) =>
            await _roleRepository.GetByIdAsync(id);

        public async Task UpdateRoleAsync(Role role)
        {
            await _roleRepository.UpdateAsync(role);
            await _redisCache.RemoveAsync(CacheKey);
        }
    }
}
