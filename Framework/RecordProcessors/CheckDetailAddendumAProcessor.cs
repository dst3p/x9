using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class CheckDetailAddendumAProcessor : RecordProcessor<CheckDetailAddendumA>, IRecordProcessor
	{
		public string RecordType { get; set; } = "26";
        public virtual int CheckDetailAddendumARecordNumberBytes => 1;
        public virtual int BankOfFirstDepositRoutingNumberBytes => 9;
        public virtual int BankOfFirstDepositBusinessDateBytes => 8;
        public virtual int BankOfFirstDepositItemsSequenceNumberBytes => 15;
        public virtual int DepositAccountNumberAtBankOfFirstDepositBytes => 18;
        public virtual int BankOfFirstDepositDepositBranchBytes => 5;
        public virtual int PayeeNameBytes => 15;
        public virtual int TruncationIndicatorBytes => 1;
        public virtual int BankOfFirstDepositConversionIndicatorBytes => 1;
        public virtual int EndorsingBankIdentifierBytes => 1;
        public virtual int UserFieldBytes => 1;
        public virtual int ReservedBytes => 3;

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentCheckItem.CheckDetailAddendumAs.Add(Model);
		}

		protected override CheckDetailAddendumA PopulateModel()
		{
			var checkDetailAddendumA = new CheckDetailAddendumA();

            checkDetailAddendumA.CheckDetailAddendumARecordNumber = Parent.X9Reader.ReadBytesAndConvert(CheckDetailAddendumARecordNumberBytes);
            checkDetailAddendumA.BankOfFirstDepositRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositRoutingNumberBytes);
            checkDetailAddendumA.BankOfFirstDepositBusinessDate = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositBusinessDateBytes);
            checkDetailAddendumA.BankOfFirstDepositItemsSequenceNumber = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositItemsSequenceNumberBytes);
            checkDetailAddendumA.DepositAccountNumberAtBankOfFirstDeposit = Parent.X9Reader.ReadBytesAndConvert(DepositAccountNumberAtBankOfFirstDepositBytes);
            checkDetailAddendumA.BankOfFirstDepositDepositBranch = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositDepositBranchBytes);
            checkDetailAddendumA.PayeeName = Parent.X9Reader.ReadBytesAndConvert(PayeeNameBytes);
            checkDetailAddendumA.TruncationIndicator = Parent.X9Reader.ReadBytesAndConvert(TruncationIndicatorBytes);
            checkDetailAddendumA.BankOfFirstDepositConversionIndicator = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositConversionIndicatorBytes);
            checkDetailAddendumA.EndorsingBankIdentifier = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankIdentifierBytes);
            checkDetailAddendumA.UserField = Parent.X9Reader.ReadBytesAndConvert(UserFieldBytes);
            checkDetailAddendumA.Reserved = Parent.X9Reader.ReadBytesAndConvert(ReservedBytes);

            return checkDetailAddendumA;
		}
	}
}
