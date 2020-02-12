namespace X9.Models
{
    public class BundleControl : X9Record
    {
        public override string RecordType { get; set; } = "70";
        public string BundleItemCount { get; set; }
        public string BundleTotalAmount { get; set; }
        public string MicrValidTotalAmount { get; set; }
        public string ImagesWithinBundleCount { get; set; }
		public string UserField { get; set; }
		public string Reserved { get; set; }
    }
}
