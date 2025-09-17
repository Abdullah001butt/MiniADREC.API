namespace MiniADREC.Domain.Entities
{
    public class Plot
    {
        public long Id { get; set; }
        public string PlotNumber { get; set; }
        public string District { get; set; }
        public string LandUse { get; set; }
        public string OwnerName { get; set; }
    }
}
