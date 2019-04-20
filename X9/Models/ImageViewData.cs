namespace Tcb.X9.Models
{
	public class ImageViewData : X9Record
	{
		public override string RecordType { get; set; } = "52";

		public string EceInstitutionRoutingNumber { get; set; }

		public string BundleBusinessDate { get; set; }

		public string CycleNumber { get; set; }

		public string EceInstitutionItemSequenceNumber { get; set; }

		public string SecurityOriginatorName { get; set; }

		public string SecurityAuthenticatorName { get; set; }

		public string SecurityKeyName { get; set; }

		public string ClippingOrigin { get; set; }

		public string ClippingCoordinateH1 { get; set; }

		public string ClippingCoordinateH2 { get; set; }

		public string ClippingCoordinateV1 { get; set; }

		public string ClippingCoordinateV2 { get; set; }

		public int ImageReferenceKeyLength { get; set; }

		public string ImageReferenceKey { get; set; }

		public int DigitalSignatureLength { get; set; }

		public string DigitalSignature { get; set; }

		public int ImageDataLength { get; set; }

		public byte[] Data { get; set; }
	}
}
