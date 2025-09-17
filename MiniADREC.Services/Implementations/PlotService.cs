using AutoMapper;
using MiniADREC.Domain.Entities;
using MiniADREC.DTO.Plot;
using MiniADREC.Repositories.Interfaces;
using MiniADREC.Services.Interfaces;

namespace MiniADREC.Services.Implementations
{
    public class PlotService : IPlotService
    {
        private readonly IPlotRepository _plotRepository;
        private readonly IMapper _mapper;

        public PlotService(IPlotRepository plotRepository, IMapper mapper)
        {
            _plotRepository = plotRepository;
            _mapper = mapper;
        }

        public async Task CreatePlotAsync(CreatePlotDto dto)
        {
            var plot = _mapper.Map<Plot>(dto);
            await _plotRepository.AddAsync(plot);
        }

        public async Task DeletePlotAsync(long id)
        {
            await _plotRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PlotDto>> GetAllPlotsAsync()
        {
            var plots = await _plotRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlotDto>>(plots);
        }

        public async Task<PlotDto?> GetPlotByIdAsync(long id)
        {
            var plot = await _plotRepository.GetByIdAsync(id);
            return plot == null ? null : _mapper.Map<PlotDto>(plot);
        }

        public async Task<IEnumerable<PlotDto>> SearchPlotsAsync(string district, string landUse)
        {
            var plots = await _plotRepository.SearchAsync(district, landUse);
            return _mapper.Map<IEnumerable<PlotDto>>(plots);
        }

        public async Task UpdatePlotAsync(PlotDto dto)
        {
            var plot = _mapper.Map<Plot>(dto);
            await _plotRepository.UpdateAsync(plot);
        }
    }
}
