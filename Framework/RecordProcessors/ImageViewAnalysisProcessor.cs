using X9.Models;
using X9.RecordProcessors.Interface;

namespace X9.RecordProcessors
{
    public class ImageViewAnalysisProcessor : BaseRecordProcessor<ImageViewAnalysis>, ITypeProcessor
	{
		public string RecordType { get; set; } = "54";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentImage.ImageViewAnalysis = Model;
		}

		protected override ImageViewAnalysis PopulateModel()
		{
			return new ImageViewAnalysis();
		}
	}
}
