using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ImageViewAnalysisProcessor : RecordProcessor<ImageViewAnalysis>, IRecordProcessor
	{
		public string RecordType { get; set; } = "54";
        public virtual int GlobalImageQualityBytes => 1;
        public virtual int GlobalImageUsabilityBytes => 1;
        public virtual int ImagingBankSpecificTestBytes => 1;
        public virtual int PartialImageBytes => 1;
        public virtual int ExcessiveImageSkewBytes => 1;
        public virtual int PiggybackImageBytes => 1;
        public virtual int TooLightOrTooDarkBytes => 1;
        public virtual int StreakAndOrBandsBytes => 1;
        public virtual int BelowMinimumImageSizeBytes => 1;
        public virtual int ExceedsMaximumImageSizeBytes => 1;
        public virtual int ReservedBytes => 13;
        public virtual int ImageEnabledPODBytes => 1;
        public virtual int SourceDocumentBadBytes => 1;
        public virtual int DateUsabilityBytes => 1;
        public virtual int PayeeUsabilityBytes => 1;
        public virtual int ConvenienceAmountUsabilityBytes => 1;
        public virtual int AmountInWordsUsabilityBytes => 1;
        public virtual int SignatureUsabilityBytes => 1;
        public virtual int PayorNameAndAddressUsabilityBytes => 1;
        public virtual int MicrLineUsabilityBytes => 1;
        public virtual int MemoLineUsabilityBytes => 1;
        public virtual int PayorBankNameAndAddressUsabilityBytes => 1;
        public virtual int PayeeEndorsementUsabilityBytes => 1;
        public virtual int BankOfFirstDepositEndorsementUsabilityBytes => 1;
        public virtual int TransitEndorsementUsabilityBytes => 1;
        public virtual int Reserved2Bytes => 6;
        public virtual int UserFieldBytes => 20;
        public virtual int Reserved3Bytes => 15;

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentImage.ImageViewAnalysis = Model;
		}

		protected override ImageViewAnalysis PopulateModel()
		{
			var imageViewAnalysis = new ImageViewAnalysis();

            imageViewAnalysis.GlobalImageQuality = Parent.X9Reader.ReadBytesAndConvert(GlobalImageQualityBytes);
            imageViewAnalysis.GlobalImageUsability = Parent.X9Reader.ReadBytesAndConvert(GlobalImageUsabilityBytes);
            imageViewAnalysis.ImagingBankSpecificTest = Parent.X9Reader.ReadBytesAndConvert(ImagingBankSpecificTestBytes);
            imageViewAnalysis.PartialImage = Parent.X9Reader.ReadBytesAndConvert(PartialImageBytes);
            imageViewAnalysis.ExcessiveImageSkew = Parent.X9Reader.ReadBytesAndConvert(ExcessiveImageSkewBytes);
            imageViewAnalysis.PiggybackImage = Parent.X9Reader.ReadBytesAndConvert(PiggybackImageBytes);
            imageViewAnalysis.TooLightOrTooDark = Parent.X9Reader.ReadBytesAndConvert(TooLightOrTooDarkBytes);
            imageViewAnalysis.StreakAndOrBands = Parent.X9Reader.ReadBytesAndConvert(StreakAndOrBandsBytes);
            imageViewAnalysis.BelowMinimumImageSize = Parent.X9Reader.ReadBytesAndConvert(BelowMinimumImageSizeBytes);
            imageViewAnalysis.ExceedsMaximumImageSize = Parent.X9Reader.ReadBytesAndConvert(ExceedsMaximumImageSizeBytes);
            imageViewAnalysis.Reserved = Parent.X9Reader.ReadBytesAndConvert(ReservedBytes);
            imageViewAnalysis.ImageEnabledPOD = Parent.X9Reader.ReadBytesAndConvert(ImageEnabledPODBytes);
            imageViewAnalysis.SourceDocumentBad = Parent.X9Reader.ReadBytesAndConvert(SourceDocumentBadBytes);
            imageViewAnalysis.DateUsability = Parent.X9Reader.ReadBytesAndConvert(DateUsabilityBytes);
            imageViewAnalysis.PayeeUsability = Parent.X9Reader.ReadBytesAndConvert(PayeeUsabilityBytes);
            imageViewAnalysis.ConvenienceAmountUsability = Parent.X9Reader.ReadBytesAndConvert(ConvenienceAmountUsabilityBytes);
            imageViewAnalysis.AmountInWordsUsability = Parent.X9Reader.ReadBytesAndConvert(AmountInWordsUsabilityBytes);
            imageViewAnalysis.SignatureUsability = Parent.X9Reader.ReadBytesAndConvert(SignatureUsabilityBytes);
            imageViewAnalysis.PayorNameAndAddressUsability = Parent.X9Reader.ReadBytesAndConvert(PayorNameAndAddressUsabilityBytes);
            imageViewAnalysis.MicrLineUsability = Parent.X9Reader.ReadBytesAndConvert(MicrLineUsabilityBytes);
            imageViewAnalysis.MemoLineUsability = Parent.X9Reader.ReadBytesAndConvert(MemoLineUsabilityBytes);
            imageViewAnalysis.PayorBankNameAndAddressUsability = Parent.X9Reader.ReadBytesAndConvert(PayorBankNameAndAddressUsabilityBytes);
            imageViewAnalysis.PayeeEndorsementUsability = Parent.X9Reader.ReadBytesAndConvert(PayeeEndorsementUsabilityBytes);
            imageViewAnalysis.BankOfFirstDepositEndorsementUsability = Parent.X9Reader.ReadBytesAndConvert(BankOfFirstDepositEndorsementUsabilityBytes);
            imageViewAnalysis.TransitEndorsementUsability = Parent.X9Reader.ReadBytesAndConvert(TransitEndorsementUsabilityBytes);
            imageViewAnalysis.Reserved2 = Parent.X9Reader.ReadBytesAndConvert(Reserved2Bytes);
            imageViewAnalysis.UserField = Parent.X9Reader.ReadBytesAndConvert(UserFieldBytes);
            imageViewAnalysis.Reserved3 = Parent.X9Reader.ReadBytesAndConvert(Reserved3Bytes);

            return imageViewAnalysis;
		}
	}
}
