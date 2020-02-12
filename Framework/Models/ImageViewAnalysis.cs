namespace X9.Models
{
    public class ImageViewAnalysis : X9Record
	{
		public override string RecordType { get; set; } = "54";
        public string GlobalImageQuality { get; set; }
        public string GlobalImageUsability { get; set; }
        public string ImagingBankSpecificTest { get; set; }
        public string PartialImage { get; set; }
        public string ExcessiveImageSkew { get; set; }
        public string PiggybackImage { get; set; }
        public string TooLightOrTooDark { get; set; }
        public string StreakAndOrBands { get; set; }
        public string BelowMinimumImageSize { get; set; }
        public string ExceedsMaximumImageSize { get; set; }
        public string Reserved { get; set; }
        public string ImageEnabledPOD { get; set; }
        public string SourceDocumentBad { get; set; }
        public string DateUsability { get; set; }
        public string PayeeUsability { get; set; }
        public string ConvenienceAmountUsability { get; set; }
        public string AmountInWordsUsability { get; set; }
        public string SignatureUsability { get; set; }
        public string PayorNameAndAddressUsability { get; set; }
        public string MicrLineUsability { get; set; }
        public string MemoLineUsability { get; set; }
        public string PayorBankNameAndAddressUsability { get; set; }
        public string PayeeEndorsementUsability { get; set; }
        public string BankOfFirstDepositEndorsementUsability { get; set; }
        public string TransitEndorsementUsability { get; set; }
        public string Reserved2 { get; set; }
        public string UserField { get; set; }
        public string Reserved3 { get; set; }
	}
}
