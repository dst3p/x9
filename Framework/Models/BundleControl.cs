namespace X9.Models
{
    public class BundleControl : X9Record
    {
        public override string RecordType { get; set; } = "70";
        public string UndefinedRegion { get; set; }
        public string MicrValidTotalAmount { get; set; }
    }
}
