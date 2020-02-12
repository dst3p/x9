namespace X9.Models
{
    public class BundleHeader : X9Record
    {
        public override string RecordType { get; set; } = "20";

        public string CollectionTypeIndicator { get; set; }
        public string BundleDestinationRoutingNumber { get; set; }
        public string BundleClientInstitutionRoutingNumber { get; set; }
        public string BundleBusinessDate { get; set; }
        public string BundleCreationDate { get; set; }
        public string BundleId { get; set; }
        public string BundleSequenceNumber { get; set; }
        public string CycleNumber { get; set; }
        public string ReturnLocationRoutingNumber { get; set; }
        public string UserField { get; set; }
        public string Reserved { get; set; }
    }
}
