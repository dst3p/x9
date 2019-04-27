using System;
using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ImageViewDataProcessor : RecordProcessor<ImageViewData>, IRecordProcessor
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

			Parent.CurrentImage.ImageViewData = Model;
		}

		protected override ImageViewData PopulateModel()
		{
			var imageData = new ImageViewData();

			imageData.EceInstitutionRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(EceInstitutionRoutingNumberBytes);
			imageData.BundleBusinessDate = Parent.X9Reader.ReadBytesAndConvert(BundleBusinessDateBytes);
			imageData.CycleNumber = Parent.X9Reader.ReadBytesAndConvert(CycleNumberBytes);
			imageData.EceInstitutionItemSequenceNumber = Parent.X9Reader.ReadBytesAndConvert(EceInstitutionItemSequenceNumberBytes);
			imageData.SecurityOriginatorName = Parent.X9Reader.ReadBytesAndConvert(SecurityOriginatorNameBytes);
			imageData.SecurityAuthenticatorName = Parent.X9Reader.ReadBytesAndConvert(SecurityAuthenticatorNameBytes);
			imageData.SecurityKeyName = Parent.X9Reader.ReadBytesAndConvert(SecurityKeyNameBytes);
			imageData.ClippingOrigin = Parent.X9Reader.ReadBytesAndConvert(ClippingOriginBytes);
			imageData.ClippingCoordinateH1 = Parent.X9Reader.ReadBytesAndConvert(ClippingCoordinateH1Bytes);
			imageData.ClippingCoordinateH2 = Parent.X9Reader.ReadBytesAndConvert(ClippingCoordinateH2Bytes);
			imageData.ClippingCoordinateV1 = Parent.X9Reader.ReadBytesAndConvert(ClippingCoordinateV1Bytes);
			imageData.ClippingCoordinateV2 = Parent.X9Reader.ReadBytesAndConvert(ClippingCoordinateV2Bytes);
			imageData.ImageReferenceKeyLength = Convert.ToInt32(Parent.X9Reader.ReadBytesAndConvert(ImageReferenceKeyLengthBytes));
			imageData.ImageReferenceKey = Parent.X9Reader.ReadBytesAndConvert(imageData.ImageReferenceKeyLength);
			imageData.DigitalSignatureLength = Convert.ToInt32(Parent.X9Reader.ReadBytesAndConvert(DigitalSignatureLengthBytes));
			imageData.DigitalSignature = Parent.X9Reader.ReadBytesAndConvert(imageData.DigitalSignatureLength);
			imageData.ImageDataLength = Convert.ToInt32(Parent.X9Reader.ReadBytesAndConvert(ImageDataLengthBytes));
			imageData.Data = Parent.X9Reader.ReadBytes(imageData.ImageDataLength);

			return imageData;
		}
	}
}
