using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class CreditRecordProcessor : RecordProcessor<CreditReconciliationRecord>, IRecordProcessor
    {
        public string RecordType { get; set; } = "61";
        public virtual int RecordUsageIndicatorBytes => 1;
        public virtual int AuxiliaryOnUsBytes => 15;
        public virtual int ExternalProcessingCodeBytes => 1;
        public virtual int PostingBankRoutingNumberBytes => 9;
        public virtual int PostingAccountNumberBytes => 20;
        public virtual int ItemAmountBytes => 10;
        public virtual int ItemSequenceNumberBytes => 15;
        public virtual int DocumentationTypeIndicatorBytes => 1;
        public virtual int TypeOfAccountCodeBytes => 1;
        public virtual int SourceOfWorkCodeBytes => 2;
        public virtual int ReservedBytes => 3;

        public override void Execute()
        {
            base.Execute();

            Parent.CurrentBundle.CreditRecord = Model;
        }

        protected override CreditReconciliationRecord PopulateModel()
        {
            var creditRecord = new CreditReconciliationRecord();

            creditRecord.RecordUsageIndicator = Parent.X9Reader.ReadBytesAndConvert(RecordUsageIndicatorBytes);
            creditRecord.AuxiliaryOnUs = Parent.X9Reader.ReadBytesAndConvert(AuxiliaryOnUsBytes);
            creditRecord.ExternalProcessingCode = Parent.X9Reader.ReadBytesAndConvert(ExternalProcessingCodeBytes);
            creditRecord.PostingBankRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(PostingBankRoutingNumberBytes);
            creditRecord.PostingAccountNumber = Parent.X9Reader.ReadBytesAndConvert(PostingAccountNumberBytes);
            creditRecord.ItemAmount = Parent.X9Reader.ReadBytesAndConvert(ItemAmountBytes);
            creditRecord.ItemSequenceNumber = Parent.X9Reader.ReadBytesAndConvert(ItemSequenceNumberBytes);
            creditRecord.DocumentationTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(DocumentationTypeIndicatorBytes);
            creditRecord.TypeOfAccountCode = Parent.X9Reader.ReadBytesAndConvert(TypeOfAccountCodeBytes);
            creditRecord.SourceOfWorkCode = Parent.X9Reader.ReadBytesAndConvert(SourceOfWorkCodeBytes);
            creditRecord.Reserved = Parent.X9Reader.ReadBytesAndConvert(ReservedBytes);

            return creditRecord;
        }
    }
}