using X9.Common;
using X9.Models;
using X9.Models.FileStructure;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ReturnProcessor : BaseRecordProcessor<Return>, ITypeProcessor
	{
		public string RecordType { get; set; } = "31";

		#region Record Bytes

		public virtual int PayorBankRoutingNumBytes => 8;

		public virtual int PayorBankRoutingNumberCheckDigitNumBytes => 1;

		public virtual int OnUsReturnRecordNumBytes => 20;

		public virtual int ItemAmountNumBytes => 10;

		public virtual int ReturnReasonNumBytes => 1;

		public virtual int ReturnRecordAddendumCountNumBytes => 2;

		public virtual int ReturnDocumentationTypeIndicatorNumBytes => 1;

		public virtual int ForwardBundleDateNumBytes => 8;

		public virtual int ECEInstitutionItemSequenceNumberNumBytes => 15;

		public virtual int ExternalProcessingCodeNumBytes => 1;

		public virtual int ReturnNotificationIndicatorNumBytes => 1;

		public virtual int ReturnArchiveTypeIndicatorNumBytes => 1;

		public virtual int ReservedNumBytes => 9;

		#endregion Record Bytes

		public override void Execute()
		{
			if (Parent.CurrentReturnItem != null)
			{
				Parent.CurrentBundle.ReturnItems.Add(Parent.CurrentReturnItem);
			}

			base.Execute();

			Parent.CurrentReturnItem = new X9ReturnItem
			{
				Return = Model
			};

			Parent.CurrentBundle.BundleType = BundleType.Return;
		}

		protected override Return PopulateModel()
		{
			// Read from FileStream in order
			// NOTE: ORDER HERE IS IMPORTANT - we are reading this record sequentially
			// based on the X937 spec.
			return new Return(
				Parent.X9Reader.ReadBytesAndConvert(PayorBankRoutingNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(PayorBankRoutingNumberCheckDigitNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(OnUsReturnRecordNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(ItemAmountNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(ReturnReasonNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(ReturnRecordAddendumCountNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(ReturnDocumentationTypeIndicatorNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(ForwardBundleDateNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(ECEInstitutionItemSequenceNumberNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(ExternalProcessingCodeNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(ReturnNotificationIndicatorNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(ReturnArchiveTypeIndicatorNumBytes),
				Parent.X9Reader.ReadBytesAndConvert(ReservedNumBytes)
			);
		}
	}
}
