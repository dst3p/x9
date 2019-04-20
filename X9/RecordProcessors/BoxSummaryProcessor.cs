using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class BoxSummaryProcessor : BaseRecordProcessor<BoxSummary>, IBaseProcessor
	{
		public string RecordType { get; set; } = "75";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentBundle.BoxSummary = Model;
		}

		protected override BoxSummary PopulateModel()
		{
			return new BoxSummary();
		}
	}
}
