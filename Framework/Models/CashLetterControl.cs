namespace X9.Models
{
    public class CashLetterControl : X9Record
    {
        public override string RecordType { get; set; } = "90";
        public string UndefinedRegion { get; set; }
        public string SettlementDate { get; set; }
    }
}
