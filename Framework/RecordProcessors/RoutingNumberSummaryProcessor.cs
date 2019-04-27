using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class RoutingNumberSummaryProcessor : RecordProcessor<RoutingNumberSummary>, IRecordProcessor
	{
		public string RecordType { get; set; } = "85";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentCashLetter.RoutingNumberSummaries.Add(Model);
		}

		protected override RoutingNumberSummary PopulateModel()
		{
			return new RoutingNumberSummary();
		}
	}
}
