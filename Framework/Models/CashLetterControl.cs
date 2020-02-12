namespace X9.Models
{
    public class CashLetterControl : X9Record
    {
        public override string RecordType { get; set; } = "90";
        public string BundleCount { get; set; }
        public string CashLetterItemCount { get; set; }
        public string CashLetterTotalAmount { get; set; }
        public string CashLetterImageViewCount { get; set; }
        public string EceInstitutionName { get; set; }
        public string SettlementDate { get; set; }
        public string Reserved { get; set; }
    }
}
