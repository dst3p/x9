using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ReturnAddendumDProcessor : BaseRecordProcessor<ReturnAddendumD>, ITypeProcessor
	{
		public string RecordType { get; set; } = "35";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentReturnItem.ReturnAddendumDs.Add(Model);
		}

		protected override ReturnAddendumD PopulateModel()
		{
			return new ReturnAddendumD();
		}
	}
}
