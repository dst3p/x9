using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class RoutingNumberSummaryProcessor : BaseRecordProcessor<RoutingNumberSummary>, IBaseProcessor
	{
		public string RecordType { get; set; } = "85";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentCashLetter.RoutingNumberSummaries.Add(Model);
		}

		protected override RoutingNumberSummary PopulateModel()
		{
			return new RoutingNumberSummary();
		}
	}
}
