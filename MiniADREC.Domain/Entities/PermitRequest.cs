namespace MiniADREC.Domain.Entities
{
    public class PermitRequest
    {
        public long Id { get; set; }

        public string Type { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime RequestedAt { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public long PlotId { get; set; }
        public Plot Plot { get; set; }
    }
}
