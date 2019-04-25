using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class FileHeaderProcessor : BaseRecordProcessor<FileHeader>, ITypeProcessor
	{
		public string RecordType { get; set; } = "01";

		public override void Execute()
		{
			base.Execute();

			Parent.FileSpec.FileHeader = Model;
		}

		protected override FileHeader PopulateModel()
		{
			return new FileHeader();
		}
	}
}
