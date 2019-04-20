using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class ReturnAddendumDProcessor : BaseRecordProcessor<ReturnAddendumD>, IBaseProcessor
	{
		public string RecordType { get; set; } = "35";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentReturnItem.ReturnAddendumDs.Add(Model);
		}

		protected override ReturnAddendumD PopulateModel()
		{
			return new ReturnAddendumD();
		}
	}
}
