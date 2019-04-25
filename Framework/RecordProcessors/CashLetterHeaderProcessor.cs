using X9.Models;
using X9.Models.FileStructure;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class CashLetterHeaderProcessor : BaseRecordProcessor<CashLetterHeader>, ITypeProcessor
	{
		public string RecordType { get; set; } = "10";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentCashLetter = new X9CashLetter
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
