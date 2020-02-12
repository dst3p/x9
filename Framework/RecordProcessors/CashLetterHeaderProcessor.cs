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
        public virtual int ClientInstitutionRoutingNumberBytes => 9;
        public virtual int CashLetterBusinessDateBytes => 8;
        public virtual int CashLetterCreationDateBytes => 8;
        public virtual int CashLetterCreationTimeBytes => 4;
        public virtual int CashLetterRecordTypeIndicatorBytes => 1;
        public virtual int CashLetterDocumentationTypeIndicatorBytes => 1;
        public virtual int CashLetterIdBytes => 8;
        public virtual int OriginatorContactNameBytes => 14;
        public virtual int OriginatorContactPhoneNumberBytes => 10;
        public virtual int FedWorkTypeBytes => 1;
        public virtual int UserFieldBytes => 2;
        public virtual int ReservedBytes => 1;

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
            cashLetterHeader.ClientInstitutionRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(ClientInstitutionRoutingNumberBytes);
            cashLetterHeader.CashLetterBusinessDate = Parent.X9Reader.ReadBytesAndConvert(CashLetterBusinessDateBytes);
            cashLetterHeader.CashLetterCreationDate = Parent.X9Reader.ReadBytesAndConvert(CashLetterCreationDateBytes);
            cashLetterHeader.CashLetterCreationTime = Parent.X9Reader.ReadBytesAndConvert(CashLetterCreationTimeBytes);
            cashLetterHeader.CashLetterRecordTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(CashLetterRecordTypeIndicatorBytes);
            cashLetterHeader.CashLetterDocumentationTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(CashLetterDocumentationTypeIndicatorBytes);
            cashLetterHeader.CashLetterId = Parent.X9Reader.ReadBytesAndConvert(CashLetterIdBytes);
            cashLetterHeader.OriginatorContactName = Parent.X9Reader.ReadBytesAndConvert(OriginatorContactNameBytes);
            cashLetterHeader.OriginatorContactPhoneNumber = Parent.X9Reader.ReadBytesAndConvert(OriginatorContactPhoneNumberBytes);
            cashLetterHeader.FedWorkType = Parent.X9Reader.ReadBytesAndConvert(FedWorkTypeBytes);
            cashLetterHeader.UserField = Parent.X9Reader.ReadBytesAndConvert(UserFieldBytes);
            cashLetterHeader.Reserved = Parent.X9Reader.ReadBytesAndConvert(ReservedBytes);

            return cashLetterHeader;
        }
    }
}
