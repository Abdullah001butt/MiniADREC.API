using AutoMapper;
using MiniADREC.Domain.Entities;
using MiniADREC.DTO.PermitRequest;
using MiniADREC.Repositories.Interfaces;
using MiniADREC.Services.Interfaces;

namespace MiniADREC.Services.Implementations
{
    public class PermitRequestService : IPermitRequestService
    {
        private readonly IPermitRequestRepository _repository;
        private readonly IMapper _mapper;

        public PermitRequestService(IPermitRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreatePermitRequestDto dto)
        {
            var request = _mapper.Map<PermitRequest>(dto);
            request.Status = "Pending";
            request.RequestedAt = DateTime.Now;

            await _repository.AddAsync(request);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PermitRequestDto>> GetAllAsync()
        {
            var requests = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PermitRequestDto>>(requests);
        }

        public async Task<PermitRequestDto?> GetByIdAsync(long id)
        {
            var request = await _repository.GetByIdAsync(id);
            return request == null ? null : _mapper.Map<PermitRequestDto>(request);
        }

        public async Task<IEnumerable<PermitRequestDto>> GetByUserIdAsync(long userId)
        {
            var requests = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<PermitRequestDto>>(requests);
        }

        public async Task UpdateStatusAsync(long id, string status)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request != null)
            {
                request.Status = status;
                await _repository.UpdateAsync(request);
            }
        }
    }
}
