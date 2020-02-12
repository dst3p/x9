using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ReturnAddendumAProcessor : RecordProcessor<ReturnAddendumA>
    {
        public string RecordType { get; set; } = "32";
        public virtual int UndefinedRegion1Bytes => 1;
        public virtual int BankOfFirstDepositRoutingNumberBytes => 9;
        public virtual int BankOfFirstDepositBusinessDateBytes => 8;
        public virtual int UndefinedRegion2Bytes => 73;
        public virtual int TruncationIndicatorBytes => 1;
        public virtual int BankOfFirstDepositConversionIndicatorBytes => 1;
        public virtual int BankOfFirstDepositCorrectionIndicatorBytes => 1;

        public override void Execute()
        {
            base.Execute();

            Parent.CurrentReturnItem.ReturnAddendumAs.Add(Model);
        }

        protected override ReturnAddendumA PopulateModel()
        {
            var returnAddendumA = new ReturnAddendumA();

            Parent.X9Reader.ReadBytes(UndefinedRegion1Bytes);
            returnAddendumA.BankOfFirstDepositRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositRoutingNumberBytes);
            returnAddendumA.BankOfFirstDepositBusinessDate = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositBusinessDateBytes);
            Parent.X9Reader.ReadBytes(UndefinedRegion2Bytes);
            returnAddendumA.TruncationIndicator = Parent.X9Reader.ReadBytesAndConvert(TruncationIndicatorBytes);
            returnAddendumA.BankOfFirstDepositConversionIndicator = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositConversionIndicatorBytes);
            returnAddendumA.BankOfFirstDepositCorrectionIndicator = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositCorrectionIndicatorBytes);
            
            return returnAddendumA;
        }
    }
}
