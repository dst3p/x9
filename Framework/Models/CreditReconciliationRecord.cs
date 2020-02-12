namespace X9.Models
{
    public class CreditReconciliationRecord : X9Record
    {
        public override string RecordType { get; set; } = "61";
        public string RecordUsageIndicator { get; set; }
        public string AuxiliaryOnUs { get; set; }
        public string ExternalProcessingCode { get; set; }
        public string PostingBankRoutingNumber { get; set; }
        public string PostingAccountNumber { get; set; }
        public string ItemAmount { get; set; }
        public string ItemSequenceNumber { get; set; }
        public string DocumentationTypeIndicator { get; set; }
        public string TypeOfAccountCode { get; set; }
        public string SourceOfWorkCode { get; set; }
        public string Reserved { get; set; }
    }
}