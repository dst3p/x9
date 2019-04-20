using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class ReturnAddendumCProcessor : BaseRecordProcessor<ReturnAddendumC>, IBaseProcessor
	{
		public string RecordType { get; set; } = "34";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentReturnItem.ReturnAddendumC = Model;
		}

		protected override ReturnAddendumC PopulateModel()
		{
			return new ReturnAddendumC();
		}
	}
}
