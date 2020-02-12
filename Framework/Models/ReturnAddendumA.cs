namespace X9.Models
{
    public class ReturnAddendumA : X9Record
    {
        public override string RecordType { get; set; } = "32";
        public string BankOfFirstDepositRoutingNumber { get; set; }
        public string BankOfFirstDepositBusinessDate { get; set; }
        public string TruncationIndicator { get; set; }
        public string BankOfFirstDepositConversionIndicator { get; set; }
        public string BankOfFirstDepositCorrectionIndicator { get; set; }
    }
}
