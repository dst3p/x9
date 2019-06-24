using X9.Models;
using X9.Models.FileStructure;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class CashLetterHeaderProcessor : RecordProcessor<CashLetterHeader>, IRecordProcessor
	{
		public string RecordType { get; set; } = "10";

        public virtual int CollectionTypeIndicatorBytes => 2;

        public virtual int DestinationRoutingNumberBytes => 9;

        public virtual int ECEInstitutionRoutingNumberBytes => 9;

        public virtual int UndefinedRegion1Bytes => 16;

        public virtual int CashLetterCreationTimeBytes => 4;

        public virtual int CashLetterRecordTypeIndicatorBytes => 1;

        public override void Execute()
		{
			base.Execute();

			Parent.CurrentCashLetter = new X9CashLetter
			{
				CashLetterHeader = Model
			};
		}

		protected override CashLetterHeader PopulateModel()
		{
			var cashLetterHeader = new CashLetterHeader();

            cashLetterHeader.CollectionTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(CollectionTypeIndicatorBytes);

            return cashLetterHeader;
		}
	}
}
