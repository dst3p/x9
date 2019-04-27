using X9.Common;
using X9.Models;
using X9.Models.FileStructure;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ImageViewDetailProcessor : RecordProcessor<ImageViewDetail>, IRecordProcessor
	{
		public string RecordType { get; set; } = "50";

		public override void Execute()
		{
			AddImageToBundle();

			base.Execute();

			Parent.CurrentImage = new X9ImageView
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
			if (Parent.CurrentImage != null)
			{
				if (Parent.CurrentBundle.BundleType == BundleType.ForwardPresentment)
				{
					Parent.CurrentCheckItem.ImageViews.Add(Parent.CurrentImage);
				}

				if (Parent.CurrentBundle.BundleType == BundleType.Return)
				{
					Parent.CurrentReturnItem.ImageViews.Add(Parent.CurrentImage);
				}
			}
		}
	}
}
