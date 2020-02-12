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

        public virtual int CashLetterDocumentationTypeIndicatorBytes => 1;

        public virtual int CashLetterIdBytes => 8;

        public virtual int UndefinedRegion2Bytes => 24;

        public virtual int FedWorkTypeBytes => 1;

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
            cashLetterHeader.DestinationRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(DestinationRoutingNumberBytes);
            cashLetterHeader.ECEInstitutionRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(ECEInstitutionRoutingNumberBytes);

            Parent.X9Reader.ReadBytesAndConvert(UndefinedRegion1Bytes);

            cashLetterHeader.CashLetterCreationTime = Parent.X9Reader.ReadBytesAndConvert(CashLetterCreationTimeBytes);
            cashLetterHeader.CashLetterRecordTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(CashLetterRecordTypeIndicatorBytes);
            cashLetterHeader.CashLetterDocumentationTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(CashLetterDocumentationTypeIndicatorBytes);
            cashLetterHeader.CashLetterId = Parent.X9Reader.ReadBytesAndConvert(CashLetterIdBytes);
            
            Parent.X9Reader.ReadBytesAndConvert(UndefinedRegion2Bytes);

            cashLetterHeader.FedWorkType = Parent.X9Reader.ReadBytesAndConvert(FedWorkTypeBytes);

            return cashLetterHeader;
		}
	}
}
