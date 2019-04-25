using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ReturnAddendumCProcessor : BaseRecordProcessor<ReturnAddendumC>, ITypeProcessor
	{
		public string RecordType { get; set; } = "34";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentReturnItem.ReturnAddendumC = Model;
		}

		protected override ReturnAddendumC PopulateModel()
		{
			return new ReturnAddendumC();
		}
	}
}
