using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class CheckDetailAddendumBProcessor : RecordProcessor<CheckDetailAddendumB>, IRecordProcessor
	{
		public string RecordType { get; set; } = "27";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentCheckItem.CheckDetailAddendumB = Model;
		}

		protected override CheckDetailAddendumB PopulateModel()
		{
			return new CheckDetailAddendumB();
		}
	}
}
