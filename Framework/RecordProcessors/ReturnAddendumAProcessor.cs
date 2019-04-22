using X9.Models;
using X9.RecordProcessors.Interface;

namespace X9.RecordProcessors
{
    public class ReturnAddendumAProcessor : BaseRecordProcessor<ReturnAddendumA>, ITypeProcessor
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
