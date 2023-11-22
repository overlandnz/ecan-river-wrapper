namespace OverlandNZ.Wrappers.ECAN.Models
{
    public class GetObservation
    {
        public string LocationId { get; set; }
        public string Name { get; set; }
        public double Nztmx { get; set; }
        public double Nztmy { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public List<Observation> Observations { get; set; }
    }
}