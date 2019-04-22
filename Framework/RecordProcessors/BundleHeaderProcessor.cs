using X9.Models;
using X9.Models.FileStructure;
using X9.RecordProcessors.Interface;

namespace X9.RecordProcessors
{
    public class BundleHeaderProcessor : BaseRecordProcessor<BundleHeader>, ITypeProcessor
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
