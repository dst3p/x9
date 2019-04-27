using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class CheckDetailAddendumAProcessor : RecordProcessor<CheckDetailAddendumA>, IRecordProcessor
	{
		public string RecordType { get; set; } = "26";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentCheckItem.CheckDetailAddendumAs.Add(Model);
		}

		protected override CheckDetailAddendumA PopulateModel()
		{
			return new CheckDetailAddendumA();
		}
	}
}
