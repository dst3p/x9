using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class AccountTotalsDetailProcessor : BaseRecordProcessor<AccountTotalsDetail>, IBaseProcessor
	{
		public string RecordType { get; set; } = "40";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentCashLetter.AccountTotalsDetails.Add(Model);
		}

		protected override AccountTotalsDetail PopulateModel()
		{
			return new AccountTotalsDetail();
		}
	}
}
