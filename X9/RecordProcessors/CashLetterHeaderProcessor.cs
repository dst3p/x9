using Tcb.X9.Models;
using Tcb.X9.Models.FileStructure;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class CashLetterHeaderProcessor : BaseRecordProcessor<CashLetterHeader>, IBaseProcessor
	{
		public string RecordType { get; set; } = "10";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentCashLetter = new X9CashLetter
			{
				CashLetterHeader = Model
			};
		}

		protected override CashLetterHeader PopulateModel()
		{
			return new CashLetterHeader();
		}
	}
}
