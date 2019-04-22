using X9.Models;
using X9.RecordProcessors.Interface;

namespace X9.RecordProcessors
{
    public class AccountTotalsDetailProcessor : BaseRecordProcessor<AccountTotalsDetail>, ITypeProcessor
	{
		public string RecordType { get; set; } = "40";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentCashLetter.AccountTotalsDetails.Add(Model);
		}

		protected override AccountTotalsDetail PopulateModel()
		{
			return new AccountTotalsDetail();
		}
	}
}
