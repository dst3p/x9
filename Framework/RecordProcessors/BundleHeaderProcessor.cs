using X9.Models;
using X9.Models.FileStructure;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class BundleHeaderProcessor : RecordProcessor<BundleHeader>, IRecordProcessor
	{
		public string RecordType { get; set; } = "20";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentBundle = new X9Bundle
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
