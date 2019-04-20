using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class ImageViewAnalysisProcessor : BaseRecordProcessor<ImageViewAnalysis>, IBaseProcessor
	{
		public string RecordType { get; set; } = "54";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.CurrentImage.ImageViewAnalysis = Model;
		}

		protected override ImageViewAnalysis PopulateModel()
		{
			return new ImageViewAnalysis();
		}
	}
}
