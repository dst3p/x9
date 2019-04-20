using Tcb.X9.Common;
using Tcb.X9.Models;
using Tcb.X9.Models.FileStructure;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class CheckDetailProcessor : BaseRecordProcessor<CheckDetail>, IBaseProcessor
	{
		public string RecordType { get; set; } = "25";

		public override void Execute()
		{
			if (ParentProcessor.CurrentCheckItem != null)
			{
				ParentProcessor.CurrentBundle.CheckItems.Add(ParentProcessor.CurrentCheckItem);
			}

			base.Execute();

			ParentProcessor.CurrentCheckItem = new X9ForwardPresentmentItem
			{
				CheckDetail = Model
			};

			ParentProcessor.CurrentBundle.BundleType = BundleType.ForwardPresentment;
		}

		protected override CheckDetail PopulateModel()
		{
			return new CheckDetail();
		}
	}
}
