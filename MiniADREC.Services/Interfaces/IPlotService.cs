using MiniADREC.DTO.Plot;

namespace MiniADREC.Services.Interfaces
{
    public interface IPlotService
    {
        Task CreatePlotAsync(CreatePlotDto dto);
        Task<IEnumerable<PlotDto>> GetAllPlotsAsync();
        Task<PlotDto?> GetPlotByIdAsync(long id);
        Task UpdatePlotAsync(PlotDto dto);
        Task DeletePlotAsync(long id);
        Task<IEnumerable<PlotDto>> SearchPlotsAsync(string district, string landUse);
    }
}
