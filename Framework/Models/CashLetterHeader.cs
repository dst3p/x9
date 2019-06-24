namespace X9.Models
{
    public class CashLetterHeader : X9Record
	{
		public override string RecordType { get; set; } = "10";

        public string CollectionTypeIndicator { get; set; }

        public string DestinationRoutingNumber { get; set; }

        public string ECEInstitutionRoutingNumber { get; set; }

        public string CashLetterCreationTime { get; set; }

        public string CashLetterRecordTypeIndicator { get; set; }
	}
}
