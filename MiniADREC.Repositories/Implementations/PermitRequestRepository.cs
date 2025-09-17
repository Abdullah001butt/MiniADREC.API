using Microsoft.EntityFrameworkCore;
using MiniADREC.Context;
using MiniADREC.Domain.Entities;
using MiniADREC.Repositories.Interfaces;

namespace MiniADREC.Repositories.Implementations
{
    public class PermitRequestRepository : IPermitRequestRepository
    {
        private readonly AppDbContext _context;

        public PermitRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PermitRequest request)
        {
            await _context.PermitRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var request = await _context.PermitRequests.FindAsync(id);
            if (request != null)
            {
                _context.PermitRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PermitRequest>> GetAllAsync()
        {
            return await _context.PermitRequests.ToListAsync();
        }

        public async Task<PermitRequest?> GetByIdAsync(long id)
        {
            return await _context.PermitRequests.FindAsync(id);
        }

        public async Task<IEnumerable<PermitRequest>> GetByUserIdAsync(long userId)
        {
            return await _context.PermitRequests
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task UpdateAsync(PermitRequest request)
        {
            _context.PermitRequests.Update(request);
            await _context.SaveChangesAsync();
        }
    }
}
