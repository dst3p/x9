using Tcb.X9.Common;
using Tcb.X9.Models;
using Tcb.X9.Models.FileStructure;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class ImageViewDetailProcessor : BaseRecordProcessor<ImageViewDetail>, IBaseProcessor
	{
		public string RecordType { get; set; } = "50";

		public override void Execute()
		{
			AddImageToBundle();

			base.Execute();

			ParentProcessor.CurrentImage = new X9ImageView
			{
				ImageViewDetail = Model
			};
		}

		protected override ImageViewDetail PopulateModel()
		{
			return new ImageViewDetail();
		}

		private void AddImageToBundle()
		{
			if (ParentProcessor.CurrentImage != null)
			{
				if (ParentProcessor.CurrentBundle.BundleType == BundleType.ForwardPresentment)
				{
					ParentProcessor.CurrentCheckItem.ImageViews.Add(ParentProcessor.CurrentImage);
				}

				if (ParentProcessor.CurrentBundle.BundleType == BundleType.Return)
				{
					ParentProcessor.CurrentReturnItem.ImageViews.Add(ParentProcessor.CurrentImage);
				}
			}
		}
	}
}
