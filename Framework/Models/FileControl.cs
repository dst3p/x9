namespace X9.Models
{
    public class FileControl : X9Record
	{
		public override string RecordType { get; set; } = "99";
        public string CashLetterCount { get; set; }
        public string TotalRecordCount { get; set; }
        public string TotalItemCount { get; set; }
        public string FileTotalAmount { get; set; }
        public string ImmediateOriginContactName { get; set; }
        public string ImmediateOriginContactPhone { get; set; }
        public string FileCreditTotalAmount { get; set; }
	}
}
