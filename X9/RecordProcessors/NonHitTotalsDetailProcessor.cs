using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class NonHitTotalsDetailProcessor : BaseRecordProcessor<NonHitTotalsDetail>, IBaseProcessor
	{
		public string RecordType { get; set; } = "41";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentCashLetter.NonHitTotalsDetails.Add(Model);
		}

		protected override NonHitTotalsDetail PopulateModel()
		{
			return new NonHitTotalsDetail();
		}
	}
}
