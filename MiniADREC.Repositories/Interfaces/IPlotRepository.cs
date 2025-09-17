using MiniADREC.Domain.Entities;

namespace MiniADREC.Repositories.Interfaces
{
    public interface IPlotRepository
    {
        Task AddAsync(Plot plot);
        Task<IEnumerable<Plot>> GetAllAsync();
        Task<Plot?> GetByIdAsync(long id);
        Task UpdateAsync(Plot plot);
        Task DeleteAsync(long id);
        Task<IEnumerable<Plot>> SearchAsync(string district, string landUse);
    }
}
