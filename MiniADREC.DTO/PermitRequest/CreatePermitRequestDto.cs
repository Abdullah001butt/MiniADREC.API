namespace MiniADREC.DTO.PermitRequest
{
    public class CreatePermitRequestDto
    {
        public string Type { get; set; }
        public string Description { get; set; }

        public long UserId { get; set; }
        public long PlotId { get; set; }
    }
}
