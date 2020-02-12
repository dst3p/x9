namespace X9.Models
{
    public class CheckDetail : X9Record
	{
		public override string RecordType { get; set; } = "25";

        public string AuxiliaryOnUs { get; set; }
        public string ExternalProcessingCode { get; set; }
        public string PayorBankRoutingNumberCheckDigit { get; set; }
        public string OnUs { get; set; }
        public string EceInstitutionItemSequenceNumber { get; set; }
        public string DocumentationTypeIndicator { get; set; }
        public string ElectronicReturnAcceptanceIndicator { get; set; }
        public string MicrValidIndicator { get; set; }
        public string BofdIndicator { get; set; }
        public string CorrectionIndicator { get; set; }
        public string ArchiveTypeIndicator { get; set; }
	}
}
