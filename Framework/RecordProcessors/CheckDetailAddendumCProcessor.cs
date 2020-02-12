using System.Xml.XPath;
using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class CheckDetailAddendumCProcessor : RecordProcessor<CheckDetailAddendumC>, IRecordProcessor
	{
		public string RecordType { get; set; } = "28";
        public virtual int CheckDetailAddendumCRecordNumberBytes => 2;
        public virtual int EndorsingBankRoutingNumberBytes => 9;
        public virtual int EndorsingBankEndorsementDateBytes => 8;
        public virtual int EndorsingBankItemSequenceNumberBytes => 15;
        public virtual int TruncationIndicatorBytes => 1;
        public virtual int EndorsingBankConversionIndicatorBytes => 1;
        public virtual int EndorsingBankCorrectionIndicatorBytes => 1;
        public virtual int ReturnReasonBytes => 1;
        public virtual int UserFieldBytes => 19;
        public virtual int EndorsingBankIdentifierBytes => 1;
        public virtual int ReservedBytes=> 20;

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentCheckItem.CheckDetailAddendumCs.Add(Model);
		}

		protected override CheckDetailAddendumC PopulateModel()
		{
			var checkDetailAddendumC = new CheckDetailAddendumC();

            checkDetailAddendumC.CheckDetailAddendumCRecordNumber = Parent.X9Reader.ReadBytesAndConvert(CheckDetailAddendumCRecordNumberBytes);
            checkDetailAddendumC.EndorsingBankRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankRoutingNumberBytes);
            checkDetailAddendumC.EndorsingBankEndorsementDate = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankEndorsementDateBytes);
            checkDetailAddendumC.EndorsingBankItemSequenceNumber = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankItemSequenceNumberBytes);
            checkDetailAddendumC.TruncationIndicator = Parent.X9Reader.ReadBytesAndConvert(TruncationIndicatorBytes);
            checkDetailAddendumC.EndorsingBankConversionIndicator = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankConversionIndicatorBytes);
            checkDetailAddendumC.EndorsingBankCorrectionIndicator = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankCorrectionIndicatorBytes);
            checkDetailAddendumC.ReturnReason = Parent.X9Reader.ReadBytesAndConvert(ReturnReasonBytes);
            checkDetailAddendumC.UserField = Parent.X9Reader.ReadBytesAndConvert(UserFieldBytes);
            checkDetailAddendumC.EndorsingBankIdentifier = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankIdentifierBytes);
            checkDetailAddendumC.Reserved = Parent.X9Reader.ReadBytesAndConvert(ReservedBytes);

            return checkDetailAddendumC;
		}
	}
}
