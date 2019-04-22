using X9.Models;
using X9.RecordProcessors.Interface;

namespace X9.RecordProcessors
{
    public class CheckDetailAddendumBProcessor : BaseRecordProcessor<CheckDetailAddendumB>, ITypeProcessor
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
