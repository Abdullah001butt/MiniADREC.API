using Microsoft.AspNetCore.Mvc;
using MiniADREC.DTO.Plot;
using MiniADREC.Services.Interfaces;

namespace MiniADREC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotController : ControllerBase
    {
        private readonly IPlotService _plotService;

        public PlotController(IPlotService plotService)
        {
            _plotService = plotService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlot([FromBody] CreatePlotDto dto)
        {
            await _plotService.CreatePlotAsync(dto);
            return Ok("Plot created successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlots()
        {
            var plots = await _plotService.GetAllPlotsAsync();
            return Ok(plots);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlotById(long id)
        {
            var plot = await _plotService.GetPlotByIdAsync(id);
            return plot == null ? NotFound() : Ok(plot);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlot([FromBody] PlotDto dto)
        {
            await _plotService.UpdatePlotAsync(dto);
            return Ok("Plot updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlot(long id)
        {
            await _plotService.DeletePlotAsync(id);
            return Ok("Plot deleted successfully");
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPlots([FromBody] string district, [FromQuery] string landUse)
        {
            var results = await _plotService.SearchPlotsAsync(district, landUse);
            return Ok(results);
        }
    }
}
