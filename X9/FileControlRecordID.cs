using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcb.X937
{
	/// <summary>
	/// Constant values that represent records parsed from the X937.
	/// </summary>
	public class FileControlRecord
	{
		public const string StartOfFile = "01";

		public const string ReturnedCheckDetail = "31";

		public const string BundleControl = "70";

		public const string CashLetterControl = "90";

		public const string EndOfFile = "99";
	}
}
