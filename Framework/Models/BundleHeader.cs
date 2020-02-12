namespace X9.Models
{
    public class BundleHeader : X9Record
	{
		public override string RecordType { get; set; } = "20";

        public string CollectionTypeIndicator {get;set;}

        public string DestinationRoutingNumber { get; set; }

        public string EceInstitutionRoutingNumber { get; set; }

        public string BundleId { get; set; }

        public string BundleSequenceNumber { get; set; }

        public string ReturnLocationRoutingNumber { get; set; }
	}
}
