using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcb.X9.Models
{
	public class FileHeader : X9Record
	{
		public override string RecordType { get; set; } = "01";

		public string SpecificationLevel { get; set; }

		public string TestFileIndicator { get; set; }

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
