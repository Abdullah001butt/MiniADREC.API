namespace MiniADREC.DTO.PermitRequest
{
    public class PermitRequestDto
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime RequestedAt { get; set; }

        public long UserId { get; set; }
        public long PlotId { get; set; }
    }
}
