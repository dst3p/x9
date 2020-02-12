namespace X9.Models
{
    public class FileHeader : X9Record
	{
		public override string RecordType { get; set; } = "01";

		public string StandardLevel { get; set; }

		public string FileTypeIndicator { get; set; }

		public string ImmediateDesignationRoutingNumber { get; set; }

		public string ImmediateOriginRoutingNumber { get; set; }

		public string FileCreationDate { get; set; }

		public string FileCreationTime { get; set; }

		public string ResendIndicator { get; set; }

		public string ImmediateDesignationName { get; set; }

		public string ImmediateOriginName { get; set; }

		public string FileIdModifier { get; set; }

		public string CountryCode { get; set; }

		public string UserField { get; set; }

		public string Reserved { get; set; }
	}
}
