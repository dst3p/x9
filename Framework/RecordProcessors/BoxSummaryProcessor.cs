using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class BoxSummaryProcessor : BaseRecordProcessor<BoxSummary>, ITypeProcessor
	{
		public string RecordType { get; set; } = "75";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentBundle.BoxSummary = Model;
		}

		protected override BoxSummary PopulateModel()
		{
			return new BoxSummary();
		}
	}
}
