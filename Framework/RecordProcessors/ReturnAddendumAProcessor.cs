using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ReturnAddendumAProcessor : BaseRecordProcessor<ReturnAddendumA>
	{
		public string RecordType { get; set; } = "32";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentReturnItem.ReturnAddendumAs.Add(Model);
		}

		protected override ReturnAddendumA PopulateModel()
		{
			return new ReturnAddendumA();
		}
	}
}
