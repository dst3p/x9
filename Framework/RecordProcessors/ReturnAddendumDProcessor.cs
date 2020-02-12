using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ReturnAddendumDProcessor : RecordProcessor<ReturnAddendumD>, IRecordProcessor
	{
		public string RecordType { get; set; } = "35";
        public virtual int ReturnAddendumDRecordNumberBytes => 2;
        public virtual int EndorsingBankRoutingNumberBytes => 9;
        public virtual int EndorsingBankEndorsementDateBytes => 8;
        public virtual int EndorsingBankItemSequenceNumberBytes => 15;
        public virtual int TruncationIndicatorBytes => 1;
        public virtual int EndorsingBankConversionIndicatorBytes => 1;
        public virtual int EndorsingBankCorrectionIndicatorBytes => 1;
        public virtual int ReturnReasonBytes => 1;

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentReturnItem.ReturnAddendumDs.Add(Model);
		}

		protected override ReturnAddendumD PopulateModel()
		{
			var returnAddendumD = new ReturnAddendumD();

            returnAddendumD.ReturnAddendumDRecordNumber = Parent.X9Reader.ReadBytesAndConvert(ReturnAddendumDRecordNumberBytes);
            returnAddendumD.EndorsingBankRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankRoutingNumberBytes);
            returnAddendumD.EndorsingBankEndorsementDate = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankEndorsementDateBytes);
            returnAddendumD.EndorsingBankItemSequenceNumber = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankItemSequenceNumberBytes);
            returnAddendumD.TruncationIndicator = Parent.X9Reader.ReadBytesAndConvert(TruncationIndicatorBytes);
            returnAddendumD.EndorsingBankConversionIndicator = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankConversionIndicatorBytes);
            returnAddendumD.EndorsingBankCorrectionIndicator = Parent.X9Reader.ReadBytesAndConvert(EndorsingBankCorrectionIndicatorBytes);
            returnAddendumD.ReturnReason = Parent.X9Reader.ReadBytesAndConvert(ReturnReasonBytes);

            return returnAddendumD;
		}
	}
}
