using Microsoft.EntityFrameworkCore;
using MiniADREC.Context;
using MiniADREC.Domain.Entities;
using MiniADREC.Repositories.Interfaces;

namespace MiniADREC.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _context.Users.Include(u => u.Roles).ToListAsync();

        public async Task<User?> GetByIdAsync(int id) =>
            await _context.Users.Include(u => u.Roles)
                                .FirstOrDefaultAsync(u => u.Id == id);

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
