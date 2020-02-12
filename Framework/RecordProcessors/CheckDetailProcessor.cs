using X9.Common;
using X9.Models;
using X9.Models.FileStructure;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class CheckDetailProcessor : RecordProcessor<CheckDetail>, IRecordProcessor
	{
		public string RecordType { get; set; } = "25";
        public virtual int AuxiliaryOnUsBytes => 15;
        public virtual int ExternalProcessingCodeBytes => 1;
        public virtual int PayorBankRoutingNumberBytes => 8;
        public virtual int PayorBankRoutingNumberCheckDigitBytes => 1;
        public virtual int OnUsBytes => 20;
        public virtual int ItemAmountBytes => 10;
        public virtual int EceInstitutionItemSequenceNumberBytes => 15;
        public virtual int DocumentationTypeIndicatorBytes => 1;
        public virtual int ElectronicReturnAcceptanceIndicatorBytes => 1;
        public virtual int MicrValidIndicatorBytes => 1;
        public virtual int BofdIndicatorBytes => 1;
        public virtual int CheckDetailRecordAddendumCountBytes => 2;
        public virtual int CorrectionIndicatorBytes => 1;
        public virtual int ArchiveTypeIndicatorBytes => 1;

		public override void Execute()
		{
            base.Execute();

			Parent.CurrentCheckItem = new X9ForwardPresentmentItem
			{
				CheckDetail = Model
			};

            Parent.CurrentBundle.CheckItems.Add(Parent.CurrentCheckItem);
			Parent.CurrentBundle.BundleType = BundleType.ForwardPresentment;
		}

		protected override CheckDetail PopulateModel()
		{
			var checkDetail = new CheckDetail();

            checkDetail.AuxiliaryOnUs = Parent.X9Reader.ReadBytesAndConvert(AuxiliaryOnUsBytes);
            checkDetail.ExternalProcessingCode = Parent.X9Reader.ReadBytesAndConvert(ExternalProcessingCodeBytes);
            checkDetail.PayorBankRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(PayorBankRoutingNumberBytes);
            checkDetail.PayorBankRoutingNumberCheckDigit = Parent.X9Reader.ReadBytesAndConvert(PayorBankRoutingNumberCheckDigitBytes);
            checkDetail.OnUs = Parent.X9Reader.ReadBytesAndConvert(OnUsBytes);
            checkDetail.ItemAmount = Parent.X9Reader.ReadBytesAndConvert(ItemAmountBytes);
            checkDetail.EceInstitutionItemSequenceNumber = Parent.X9Reader.ReadBytesAndConvert(EceInstitutionItemSequenceNumberBytes);
            checkDetail.DocumentationTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(DocumentationTypeIndicatorBytes);
            checkDetail.ElectronicReturnAcceptanceIndicator = Parent.X9Reader.ReadBytesAndConvert(ElectronicReturnAcceptanceIndicatorBytes);
            checkDetail.MicrValidIndicator = Parent.X9Reader.ReadBytesAndConvert(MicrValidIndicatorBytes);
            checkDetail.BofdIndicator = Parent.X9Reader.ReadBytesAndConvert(BofdIndicatorBytes);
            checkDetail.CheckDetailRecordAddendumCount = Parent.X9Reader.ReadBytesAndConvert(CheckDetailRecordAddendumCountBytes);
            checkDetail.CorrectionIndicator = Parent.X9Reader.ReadBytesAndConvert(CorrectionIndicatorBytes);
            checkDetail.ArchiveTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(ArchiveTypeIndicatorBytes);

            return checkDetail;
		}
	}
}
