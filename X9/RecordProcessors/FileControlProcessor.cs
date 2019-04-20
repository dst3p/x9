using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class FileControlProcessor : BaseRecordProcessor<FileControl>, IBaseProcessor
	{
		public string RecordType { get; set; } = "99";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.FileSpec.FileControl = Model;
		}

		protected override FileControl PopulateModel()
		{
			return new FileControl();
		}
	}
}
