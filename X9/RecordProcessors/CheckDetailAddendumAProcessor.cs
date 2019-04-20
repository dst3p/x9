using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class CheckDetailAddendumAProcessor : BaseRecordProcessor<CheckDetailAddendumA>, IBaseProcessor
	{
		public string RecordType { get; set; } = "26";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentCheckItem.CheckDetailAddendumAs.Add(Model);
		}

		protected override CheckDetailAddendumA PopulateModel()
		{
			return new CheckDetailAddendumA();
		}
	}
}
