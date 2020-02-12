namespace X9.Models
{
    public class CheckDetailAddendumA : X9Record
	{
		public override string RecordType { get; set; } = "26";

        public string CheckDetailAddendumARecordNumber { get; set; }
        public string BankOfFirstDepositRoutingNumber { get; set; }
        public string BankOfFirstDepositBusinessDate { get; set; }
        public string TruncationIndicator { get; set; }
	}
}
