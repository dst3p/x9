using X9.Models;
using X9.RecordProcessors.Interface;

namespace X9.RecordProcessors
{
    public class RoutingNumberSummaryProcessor : BaseRecordProcessor<RoutingNumberSummary>, ITypeProcessor
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
