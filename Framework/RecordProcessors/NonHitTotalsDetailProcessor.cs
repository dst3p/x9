using X9.Models;
using X9.RecordProcessors.Interface;

namespace X9.RecordProcessors
{
    public class NonHitTotalsDetailProcessor : BaseRecordProcessor<NonHitTotalsDetail>, ITypeProcessor
	{
		public string RecordType { get; set; } = "41";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentCashLetter.NonHitTotalsDetails.Add(Model);
		}

		protected override NonHitTotalsDetail PopulateModel()
		{
			return new NonHitTotalsDetail();
		}
	}
}
