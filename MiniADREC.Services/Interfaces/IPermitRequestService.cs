using MiniADREC.DTO.PermitRequest;

namespace MiniADREC.Services.Interfaces
{
    public interface IPermitRequestService
    {
        Task CreateAsync(CreatePermitRequestDto dto);
        Task<IEnumerable<PermitRequestDto>> GetAllAsync();
        Task<PermitRequestDto?> GetByIdAsync(long id);
        Task<IEnumerable<PermitRequestDto>> GetByUserIdAsync(long userId);
        Task UpdateStatusAsync(long id, string status);
        Task DeleteAsync(long id);
    }
}
