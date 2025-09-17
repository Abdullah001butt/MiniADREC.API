using MiniADREC.Domain.Entities;

namespace MiniADREC.Repositories.Interfaces
{
    public interface IPermitRequestRepository
    {
        Task AddAsync(PermitRequest request);
        Task<IEnumerable<PermitRequest>> GetAllAsync();
        Task<PermitRequest?> GetByIdAsync(long id);
        Task UpdateAsync(PermitRequest request);
        Task DeleteAsync(long id);
        Task<IEnumerable<PermitRequest>> GetByUserIdAsync(long userId);
    }
}
