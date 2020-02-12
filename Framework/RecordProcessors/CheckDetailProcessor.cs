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
        public virtual int UndefinedRegion1Bytes => 8;
        public virtual int PayorBankRoutingNumberCheckDigitBytes => 1;
        public virtual int OnUsBytes => 20;
        public virtual int UndefinedRegion2Bytes => 10;
        public virtual int EceInstitutionItemSequenceNumberBytes => 15;
        public virtual int DocumentationTypeIndicatorBytes => 1;
        public virtual int ElectronicReturnAcceptanceIndicatorBytes => 1;
        public virtual int MicrValidIndicatorBytes => 1;
        public virtual int BofdIndicatorBytes => 1;
        public virtual int CorrectionIndicatorBytes => 1;
        public virtual int ArchiveTypeIndicatorBytes => 1;

		public override void Execute()
		{
			if (Parent.CurrentCheckItem != null)
			{
				Parent.CurrentBundle.CheckItems.Add(Parent.CurrentCheckItem);
			}

			base.Execute();

			Parent.CurrentCheckItem = new X9ForwardPresentmentItem
			{
				CheckDetail = Model
			};

			Parent.CurrentBundle.BundleType = BundleType.ForwardPresentment;
		}

		protected override CheckDetail PopulateModel()
		{
			var checkDetail = new CheckDetail();

            checkDetail.AuxiliaryOnUs = Parent.X9Reader.ReadBytesAndConvert(AuxiliaryOnUsBytes);
            checkDetail.ExternalProcessingCode = Parent.X9Reader.ReadBytesAndConvert(ExternalProcessingCodeBytes);
            Parent.X9Reader.ReadBytes(UndefinedRegion1Bytes);
            checkDetail.PayorBankRoutingNumberCheckDigit = Parent.X9Reader.ReadBytesAndConvert(PayorBankRoutingNumberCheckDigitBytes);
            checkDetail.OnUs = Parent.X9Reader.ReadBytesAndConvert(OnUsBytes);
            Parent.X9Reader.ReadBytes(UndefinedRegion2Bytes);
            checkDetail.EceInstitutionItemSequenceNumber = Parent.X9Reader.ReadBytesAndConvert(EceInstitutionItemSequenceNumberBytes);
            checkDetail.DocumentationTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(DocumentationTypeIndicatorBytes);
            checkDetail.ElectronicReturnAcceptanceIndicator = Parent.X9Reader.ReadBytesAndConvert(ElectronicReturnAcceptanceIndicatorBytes);
            checkDetail.MicrValidIndicator = Parent.X9Reader.ReadBytesAndConvert(MicrValidIndicatorBytes);
            checkDetail.BofdIndicator = Parent.X9Reader.ReadBytesAndConvert(BofdIndicatorBytes);
            checkDetail.CorrectionIndicator = Parent.X9Reader.ReadBytesAndConvert(CorrectionIndicatorBytes);
            checkDetail.ArchiveTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(ArchiveTypeIndicatorBytes);

            return checkDetail;
		}
	}
}
