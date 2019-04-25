using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class FileControlProcessor : BaseRecordProcessor<FileControl>, ITypeProcessor
	{
		public string RecordType { get; set; } = "99";

		public override void Execute()
		{
			base.Execute();

			Parent.FileSpec.FileControl = Model;
		}

		protected override FileControl PopulateModel()
		{
			return new FileControl();
		}
	}
}
