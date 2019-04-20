using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class CheckDetailAddendumBProcessor : BaseRecordProcessor<CheckDetailAddendumB>, IBaseProcessor
	{
		public string RecordType { get; set; } = "27";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentCheckItem.CheckDetailAddendumB = Model;
		}

		protected override CheckDetailAddendumB PopulateModel()
		{
			return new CheckDetailAddendumB();
		}
	}
}
