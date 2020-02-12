namespace X9.Models
{
    public class CheckDetailAddendumA : X9Record
	{
		public override string RecordType { get; set; } = "26";

        public string CheckDetailAddendumARecordNumber { get; set; }
        public string BankOfFirstDepositRoutingNumber { get; set; }
        public string BankOfFirstDepositBusinessDate { get; set; }
        public string BankOfFirstDepositItemsSequenceNumber { get; set; }
        public string DepositAccountNumberAtBankOfFirstDeposit { get; set; }
        public string BankOfFirstDepositDepositBranch { get; set; }
        public string PayeeName { get; set; }
        public string TruncationIndicator { get; set; }
        public string BankOfFirstDepositConversionIndicator { get; set; }
        public string EndorsingBankIdentifier { get; set; }
        public string UserField { get; set; }
        public string Reserved { get; set; }
	}
}
