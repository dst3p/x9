namespace X9.Models
{
    public class ReturnAddendumB : X9Record
    {
        public override string RecordType { get; set; } = "33";

        public string AuxiliaryOnUs { get; set; }
    }
}
