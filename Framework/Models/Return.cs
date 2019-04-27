namespace X9.Models
{
    public class Return : X9Record
	{
        public Return() { }

		/// <summary>
		/// Construct the Return object with the default record type identifier of 31.
		/// </summary>
		/// <param name="payorBankRouting"></param>
		/// <param name="payorBankRoutingNumberCheckDigit"></param>
		/// <param name="onUsReturnRecord"></param>
		/// <param name="itemAmount"></param>
		/// <param name="returnReason"></param>
		/// <param name="returnRecordAddendumCount"></param>
		/// <param name="returnDocumentationTypeIndicator"></param>
		/// <param name="forwardBundleDate"></param>
		/// <param name="eceInstitutionItemSequenceNumber"></param>
		/// <param name="externalProcessingCode"></param>
		/// <param name="returnNotificationIndicator"></param>
		/// <param name="returnArchiveTypeIndicator"></param>
		/// <param name="reserved"></param>
		public Return(string payorBankRouting, string payorBankRoutingNumberCheckDigit, string onUsReturnRecord, string itemAmount, string returnReason, string returnRecordAddendumCount, string returnDocumentationTypeIndicator, string forwardBundleDate, string eceInstitutionItemSequenceNumber, string externalProcessingCode, string returnNotificationIndicator, string returnArchiveTypeIndicator, string reserved)
		{
			PayorBankRouting = payorBankRouting;
			PayorBankRoutingNumberCheckDigit = payorBankRoutingNumberCheckDigit;
			OnUsReturnRecord = onUsReturnRecord;
			ItemAmount = itemAmount;
			ReturnReason = returnReason;
			ReturnRecordAddendumCount = returnRecordAddendumCount;
			ReturnDocumentationTypeIndicator = returnDocumentationTypeIndicator;
			ForwardBundleDate = forwardBundleDate;
			ECEInstitutionItemSequenceNumber = eceInstitutionItemSequenceNumber;
			ExternalProcessingCode = externalProcessingCode;
			ReturnNotificationIndicator = returnNotificationIndicator;
			ReturnArchiveTypeIndicator = returnArchiveTypeIndicator;
			Reserved = reserved;
		}

		public override string RecordType { get; set; } = "31";

		public string PayorBankRouting { get; set; }

		public string PayorBankRoutingNumberCheckDigit { get; set; }

		public string OnUsReturnRecord { get; set; }

		public string ItemAmount { get; set; }

		public string ReturnReason { get; set; }

		public string ReturnRecordAddendumCount { get; set; }

		public string ReturnDocumentationTypeIndicator { get; set; }

		public string ForwardBundleDate { get; set; }

		public string ECEInstitutionItemSequenceNumber { get; set; }

		public string ExternalProcessingCode { get; set; }

		public string ReturnNotificationIndicator { get; set; }

		public string ReturnArchiveTypeIndicator { get; set; }

		public string Reserved { get; set; }

		public string FullRoutingNumber => PayorBankRouting + PayorBankRoutingNumberCheckDigit;

		public string AccountNumber { get; set; }

		public string CheckNumber { get; set; }
	}
}
