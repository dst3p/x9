namespace X9.Models
{
    public class CashLetterHeader : X9Record
    {
        public override string RecordType { get; set; } = "10";
        public string CollectionTypeIndicator { get; set; }
        public string DestinationRoutingNumber { get; set; }
        public string ClientInstitutionRoutingNumber { get; set; }
        public string CashLetterBusinessDate { get; set; }
        public string CashLetterCreationDate { get; set; }
        public string CashLetterCreationTime { get; set; }
        public string CashLetterRecordTypeIndicator { get; set; }
        public string CashLetterDocumentationTypeIndicator { get; set; }
        public string CashLetterId { get; set; }
        public string OriginatorContactName { get; set; }
        public string OriginatorContactPhoneNumber { get; set; }
        public string FedWorkType { get; set; }
        public string UserField { get; set; }
        public string Reserved { get; set; }
    }
}
