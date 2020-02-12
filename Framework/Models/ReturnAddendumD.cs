namespace X9.Models
{
    public class ReturnAddendumD : X9Record
    {
        public override string RecordType { get; set; } = "35";
        public string ReturnAddendumDRecordNumber { get; set; }
        public string EndorsingBankRoutingNumber { get; set; }
        public string EndorsingBankEndorsementDate { get; set; }
        public string EndorsingBankItemSequenceNumber { get; set; }
        public string TruncationIndicator { get; set; }
        public string EndorsingBankConversionIndicator { get; set; }
        public string EndorsingBankCorrectionIndicator { get; set; }
        public string ReturnReason { get; set; }
    }
}
