using System;
using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class ImageViewDataProcessor : BaseRecordProcessor<ImageViewData>, IBaseProcessor
	{
		public string RecordType { get; set; } = "52";

		#region Record Bytes

		public int RecordTypeBytes => 2;

		public int EceInstitutionRoutingNumberBytes => 9;

		public int BundleBusinessDateBytes => 8;

		public int CycleNumberBytes => 2;

		public int EceInstitutionItemSequenceNumberBytes => 15;

		public int SecurityOriginatorNameBytes => 16;

		public int SecurityAuthenticatorNameBytes => 16;

		public int SecurityKeyNameBytes => 16;

		public int ClippingOriginBytes => 1;

		public int ClippingCoordinateH1Bytes => 4;

		public int ClippingCoordinateH2Bytes => 4;

		public int ClippingCoordinateV1Bytes => 4;

		public int ClippingCoordinateV2Bytes => 4;

		public int ImageReferenceKeyLengthBytes => 4;

		public int ImageReferenceKeyBytes;

		public int DigitalSignatureLengthBytes => 5;

		public int DigitalSignatureBytes;

		public int ImageDataLengthBytes => 7;

		public int ImageBytes;

		#endregion Record Bytes

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentImage.ImageViewData = Model;
		}

		protected override ImageViewData PopulateModel()
		{
			var imageData = new ImageViewData();

			imageData.EceInstitutionRoutingNumber = ParentProcessor.X9Reader.ReadBytesAndConvert(EceInstitutionRoutingNumberBytes);
			imageData.BundleBusinessDate = ParentProcessor.X9Reader.ReadBytesAndConvert(BundleBusinessDateBytes);
			imageData.CycleNumber = ParentProcessor.X9Reader.ReadBytesAndConvert(CycleNumberBytes);
			imageData.EceInstitutionItemSequenceNumber = ParentProcessor.X9Reader.ReadBytesAndConvert(EceInstitutionItemSequenceNumberBytes);
			imageData.SecurityOriginatorName = ParentProcessor.X9Reader.ReadBytesAndConvert(SecurityOriginatorNameBytes);
			imageData.SecurityAuthenticatorName = ParentProcessor.X9Reader.ReadBytesAndConvert(SecurityAuthenticatorNameBytes);
			imageData.SecurityKeyName = ParentProcessor.X9Reader.ReadBytesAndConvert(SecurityKeyNameBytes);
			imageData.ClippingOrigin = ParentProcessor.X9Reader.ReadBytesAndConvert(ClippingOriginBytes);
			imageData.ClippingCoordinateH1 = ParentProcessor.X9Reader.ReadBytesAndConvert(ClippingCoordinateH1Bytes);
			imageData.ClippingCoordinateH2 = ParentProcessor.X9Reader.ReadBytesAndConvert(ClippingCoordinateH2Bytes);
			imageData.ClippingCoordinateV1 = ParentProcessor.X9Reader.ReadBytesAndConvert(ClippingCoordinateV1Bytes);
			imageData.ClippingCoordinateV2 = ParentProcessor.X9Reader.ReadBytesAndConvert(ClippingCoordinateV2Bytes);
			imageData.ImageReferenceKeyLength = Convert.ToInt32(ParentProcessor.X9Reader.ReadBytesAndConvert(ImageReferenceKeyLengthBytes));
			imageData.ImageReferenceKey = ParentProcessor.X9Reader.ReadBytesAndConvert(imageData.ImageReferenceKeyLength);
			imageData.DigitalSignatureLength = Convert.ToInt32(ParentProcessor.X9Reader.ReadBytesAndConvert(DigitalSignatureLengthBytes));
			imageData.DigitalSignature = ParentProcessor.X9Reader.ReadBytesAndConvert(imageData.DigitalSignatureLength);
			imageData.ImageDataLength = Convert.ToInt32(ParentProcessor.X9Reader.ReadBytesAndConvert(ImageDataLengthBytes));
			imageData.Data = ParentProcessor.X9Reader.ReadBytes(imageData.ImageDataLength);

			return imageData;
		}
	}
}
