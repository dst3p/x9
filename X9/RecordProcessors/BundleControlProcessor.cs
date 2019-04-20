using Tcb.X9.Common;
using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class BundleControlProcessor : BaseRecordProcessor<BundleControl>, IBaseProcessor
	{
		public string RecordType { get; set; } = "70";

		public override void Execute()
		{
			AddLastItemToBundle();

			base.Execute();

			if (ParentProcessor.CurrentBundle == null)
			{
				throw new System.Exception("X9 was malformed or parsed incorrectly");
			}

			ParentProcessor.CurrentBundle.BundleControl = Model;
			ParentProcessor.CurrentCashLetter.Bundles.Add(ParentProcessor.CurrentBundle);
		}

		protected override BundleControl PopulateModel()
		{
			return new BundleControl();
		}

		private void AddLastItemToBundle()
		{
			if (ParentProcessor.CurrentBundle.BundleType == BundleType.ForwardPresentment)
			{
				ParentProcessor.CurrentBundle.CheckItems.Add(ParentProcessor.CurrentCheckItem);
			}

			if (ParentProcessor.CurrentBundle.BundleType == BundleType.Return)
			{
				ParentProcessor.CurrentBundle.ReturnItems.Add(ParentProcessor.CurrentReturnItem);
			}
		}
	}
}
