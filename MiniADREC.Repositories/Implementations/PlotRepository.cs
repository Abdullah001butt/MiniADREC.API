using Microsoft.EntityFrameworkCore;
using MiniADREC.Context;
using MiniADREC.Domain.Entities;
using MiniADREC.Repositories.Interfaces;

namespace MiniADREC.Repositories.Implementations
{
    public class PlotRepository : IPlotRepository
    {
        private readonly AppDbContext _context;

        public PlotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Plot plot)
        {
            await _context.Plots.AddAsync(plot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var plot = await _context.Plots.FindAsync(id);
            if (plot != null)
            {
                _context.Plots.Remove(plot);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Plot>> GetAllAsync()
        {
            return await _context.Plots.ToListAsync();
        }

        public async Task<Plot?> GetByIdAsync(long id)
        {
            return await _context.Plots.FindAsync(id);
        }

        public async Task<IEnumerable<Plot>> SearchAsync(string district, string landUse)
        {
            return await _context.Plots
                .Where(p => p.District.Contains(district) && p.LandUse.Contains(landUse))
                .ToListAsync();
        }

        public async Task UpdateAsync(Plot plot)
        {
            _context.Plots.Update(plot);
            await _context.SaveChangesAsync();
        }
    }
}
