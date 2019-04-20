using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcb.X9;
using Tcb.X9.Common;
using Tcb.X9.Models;
using Tcb.X9.Models.FileStructure;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class ReturnProcessor : BaseRecordProcessor<Return>, IBaseProcessor
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
			if (ParentProcessor.CurrentReturnItem != null)
			{
				ParentProcessor.CurrentBundle.ReturnItems.Add(ParentProcessor.CurrentReturnItem);
			}

			base.Execute();

			ParentProcessor.CurrentReturnItem = new X9ReturnItem
			{
				Return = Model
			};

			ParentProcessor.CurrentBundle.BundleType = BundleType.Return;
		}

		protected override Return PopulateModel()
		{
			// Read from FileStream in order
			// NOTE: ORDER HERE IS IMPORTANT - we are reading this record sequentially
			// based on the X937 spec.
			return new Return(RecordType,
				ParentProcessor.X9Reader.ReadBytesAndConvert(PayorBankRoutingNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(PayorBankRoutingNumberCheckDigitNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(OnUsReturnRecordNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(ItemAmountNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(ReturnReasonNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(ReturnRecordAddendumCountNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(ReturnDocumentationTypeIndicatorNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(ForwardBundleDateNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(ECEInstitutionItemSequenceNumberNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(ExternalProcessingCodeNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(ReturnNotificationIndicatorNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(ReturnArchiveTypeIndicatorNumBytes),
				ParentProcessor.X9Reader.ReadBytesAndConvert(ReservedNumBytes)
			);
		}
	}
}
