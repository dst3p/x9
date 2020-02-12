namespace X9.Models
{
    public class ImageViewDetail : X9Record
    {
        public override string RecordType { get; set; } = "50";

        public string ImageIndicator { get; set; }
        public string ImageViewFormatIndicator { get; set; }
        public string ImageViewCompressionAlgorithmIdentifier { get; set; }
        public string ViewDescriptor { get; set; }
        public string DigitalSignatureIndicator { get; set; }
        public string DigitalSignatureMethod { get; set; }
        public string SecurityKeySize { get; set; }
        public string StartOfProtectedData { get; set; }
        public string LengthOfProtectedData { get; set; }
        public string ImageRecreateIndicator { get; set; }
    }
}
