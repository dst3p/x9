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
        public virtual int UndefinedRegion1Bytes => 73;
        public virtual int TruncationIndicatorBytes => 1;

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentCheckItem.CheckDetailAddendumAs.Add(Model);
		}

		protected override CheckDetailAddendumA PopulateModel()
		{
			var checkDetailAddendumA = new CheckDetailAddendumA();

            checkDetailAddendumA.CheckDetailAddendumARecordNumber = Parent.X9Reader.ReadBytesAndConvert(CheckDetailAddendumARecordNumberBytes);
            checkDetailAddendumA.CheckDetailAddendumARecordNumber = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositRoutingNumberBytes);
            checkDetailAddendumA.CheckDetailAddendumARecordNumber = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositBusinessDateBytes);
            
            Parent.X9Reader.ReadBytes(UndefinedRegion1Bytes);

            checkDetailAddendumA.CheckDetailAddendumARecordNumber = Parent.X9Reader.ReadBytesAndConvert(TruncationIndicatorBytes);

            return checkDetailAddendumA;
		}
	}
}
