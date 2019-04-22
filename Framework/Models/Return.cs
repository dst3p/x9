namespace X9.Models
{
    public class Return : X9Record
	{
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

		/// <summary>
		/// Construct the return object with a self-defined record identifier.
		/// </summary>
		/// <param name="recordType"></param>
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
		public Return(string recordType, string payorBankRouting, string payorBankRoutingNumberCheckDigit, string onUsReturnRecord, string itemAmount, string returnReason, string returnRecordAddendumCount, string returnDocumentationTypeIndicator, string forwardBundleDate, string eceInstitutionItemSequenceNumber, string externalProcessingCode, string returnNotificationIndicator, string returnArchiveTypeIndicator, string reserved)
		{
			RecordType = recordType;
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

		public string PayorBankRouting { get; private set; }

		public string PayorBankRoutingNumberCheckDigit { get; private set; }

		public string OnUsReturnRecord { get; private set; }

		public string ItemAmount { get; private set; }

		public string ReturnReason { get; private set; }

		public string ReturnRecordAddendumCount { get; private set; }

		public string ReturnDocumentationTypeIndicator { get; private set; }

		public string ForwardBundleDate { get; private set; }

		public string ECEInstitutionItemSequenceNumber { get; private set; }

		public string ExternalProcessingCode { get; private set; }

		public string ReturnNotificationIndicator { get; private set; }

		public string ReturnArchiveTypeIndicator { get; private set; }

		public string Reserved { get; private set; }

		public string FullRoutingNumber => PayorBankRouting + PayorBankRoutingNumberCheckDigit;

		public string AccountNumber { get; set; }

		public string CheckNumber { get; set; }
	}
}
