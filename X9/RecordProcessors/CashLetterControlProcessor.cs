using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class CashLetterControlProcessor : BaseRecordProcessor<CashLetterControl>, IBaseProcessor
	{
		public string RecordType { get; set; } = "90";

		public override void Execute()
		{
			base.Execute();

			if (ParentProcessor.CurrentCashLetter == null)
			{
				throw new System.Exception("X9 file is malformed or was parsed incorrectly.");
			}

			ParentProcessor.CurrentCashLetter.CashLetterControl = Model;

			// Add the cash letter to the file spec
			ParentProcessor.FileSpec.CashLetters.Add(ParentProcessor.CurrentCashLetter);
		}

		protected override CashLetterControl PopulateModel()
		{
			return new CashLetterControl();
		}
	}
}
