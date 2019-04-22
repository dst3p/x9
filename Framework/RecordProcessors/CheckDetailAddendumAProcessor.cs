using X9.Models;
using X9.RecordProcessors.Interface;

namespace X9.RecordProcessors
{
    public class CheckDetailAddendumAProcessor : BaseRecordProcessor<CheckDetailAddendumA>, ITypeProcessor
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
