using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class CheckDetailAddendumCProcessor : BaseRecordProcessor<CheckDetailAddendumC>, IBaseProcessor
	{
		public string RecordType { get; set; } = "28";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentCheckItem.CheckDetailAddendumCs.Add(Model);
		}

		protected override CheckDetailAddendumC PopulateModel()
		{
			return new CheckDetailAddendumC();
		}
	}
}
