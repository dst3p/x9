using X9.Common;
using X9.Models;
using X9.Models.FileStructure;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ImageViewDetailProcessor : RecordProcessor<ImageViewDetail>, IRecordProcessor
	{
		public string RecordType { get; set; } = "50";
        public virtual int ImageIndicatorBytes => 1;
        public virtual int UndefinedRegion1Bytes => 17;
        public virtual int ImageViewFormatIndicatorBytes => 2;
        public virtual int ImageViewCompressionAlgorithmIdentifierBytes => 2;
        public virtual int UndefinedRegion2Bytes => 8;
        public virtual int ViewDescriptorBytes => 2;
        public virtual int DigitalSignatureIndicatorBytes => 1;
        public virtual int DigitalSignatureMethodBytes => 2;
        public virtual int SecurityKeySizeBytes => 5;
        public virtual int StartOfProtectedDataBytes => 7;
        public virtual int LengthOfProtectedDataBytes => 7;
        public virtual int ImageRecreateIndicatorBytes => 1;

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
			var imageViewDetail = new ImageViewDetail();

            imageViewDetail.ImageIndicator = Parent.X9Reader.ReadBytesAndConvert(ImageIndicatorBytes);
            Parent.X9Reader.ReadBytes(UndefinedRegion1Bytes);
            imageViewDetail.ImageViewFormatIndicator = Parent.X9Reader.ReadBytesAndConvert(ImageViewFormatIndicatorBytes);
            imageViewDetail.ImageViewCompressionAlgorithmIdentifier = Parent.X9Reader.ReadBytesAndConvert(ImageViewCompressionAlgorithmIdentifierBytes);
            Parent.X9Reader.ReadBytes(UndefinedRegion2Bytes);
            imageViewDetail.ViewDescriptor = Parent.X9Reader.ReadBytesAndConvert(ViewDescriptorBytes);
            imageViewDetail.DigitalSignatureIndicator = Parent.X9Reader.ReadBytesAndConvert(DigitalSignatureIndicatorBytes);
            imageViewDetail.DigitalSignatureMethod = Parent.X9Reader.ReadBytesAndConvert(DigitalSignatureMethodBytes);
            imageViewDetail.SecurityKeySize = Parent.X9Reader.ReadBytesAndConvert(SecurityKeySizeBytes);
            imageViewDetail.StartOfProtectedData = Parent.X9Reader.ReadBytesAndConvert(StartOfProtectedDataBytes);
            imageViewDetail.LengthOfProtectedData = Parent.X9Reader.ReadBytesAndConvert(LengthOfProtectedDataBytes);
            imageViewDetail.ImageRecreateIndicator = Parent.X9Reader.ReadBytesAndConvert(ImageRecreateIndicatorBytes);

            return imageViewDetail;
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
