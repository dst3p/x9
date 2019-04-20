using Tcb.X9.Models;
using Tcb.X9.Models.FileStructure;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class BundleHeaderProcessor : BaseRecordProcessor<BundleHeader>, IBaseProcessor
	{
		public string RecordType { get; set; } = "20";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentBundle = new X9Bundle
			{
				BundleHeader = Model
			};
		}

		protected override BundleHeader PopulateModel()
		{
			return new BundleHeader();
		}
	}
}
