using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class ReturnAddendumBProcessor : BaseRecordProcessor<ReturnAddendumB>, IBaseProcessor
	{
		public string RecordType { get; set; } = "33";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentReturnItem.ReturnAddendumB = Model;
		}

		protected override ReturnAddendumB PopulateModel()
		{
			return new ReturnAddendumB();
		}
	}
}
