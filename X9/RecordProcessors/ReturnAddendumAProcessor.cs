using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class ReturnAddendumAProcessor : BaseRecordProcessor<ReturnAddendumA>, IBaseProcessor
	{
		public string RecordType { get; set; } = "32";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentReturnItem.ReturnAddendumAs.Add(Model);
		}

		protected override ReturnAddendumA PopulateModel()
		{
			return new ReturnAddendumA();
		}
	}
}
