using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcb.X9.Models.FileStructure
{
	public class X9CashLetter
	{
		public X9CashLetter()
		{
			CashLetterHeader = new CashLetterHeader();
			Bundles = new Collection<X9Bundle>();
			AccountTotalsDetails = new Collection<AccountTotalsDetail>();
			NonHitTotalsDetails = new Collection<NonHitTotalsDetail>();
			RoutingNumberSummaries = new Collection<RoutingNumberSummary>();
			CashLetterControl = new CashLetterControl();
		}

		public CashLetterHeader CashLetterHeader { get; set; }

		public Collection<X9Bundle> Bundles { get; set; }

		public Collection<AccountTotalsDetail> AccountTotalsDetails { get; set; }

		public Collection<NonHitTotalsDetail> NonHitTotalsDetails { get; set; }

		public Collection<RoutingNumberSummary> RoutingNumberSummaries { get; set; }

		public CashLetterControl CashLetterControl { get; set; }
	}
}
