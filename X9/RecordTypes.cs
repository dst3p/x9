using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcb.X9.X937
{
	/// <summary>
	/// Constant values that represent records supported in the X937.
	/// </summary>
	public static class RecordTypes
	{
		public const string FileHeader = "01";

		public const string CashLetterHeader = "10";

		public const string BundleHeader = "20";

		public const string CheckDetail = "25";

		public const string CheckDetailAddendumA = "26";

		public const string CheckDetailAddendumB = "27";

		public const string CheckDetailAddendumC = "28";

		public const string Return = "31";

		public const string ReturnAddendumA = "32";

		public const string ReturnAddendumB = "33";

		public const string ReturnAddendumC = "34";

		public const string ReturnAddendumD = "35";

		public const string AccountTotalsDetail = "40";

		public const string NonHitTotalsDetail = "41";

		public const string ImageViewDetail = "50";

		public const string ImageViewData = "52";

		public const string ImageViewAnalysis = "54";

		public const string BundleControl = "70";

		public const string BoxSummary = "75";

		public const string RoutingNumberSummary = "85";

		public const string CashLetterControl = "90";

		public const string FileControl = "99";
	}
}
