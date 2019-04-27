using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ImageViewAnalysisProcessor : RecordProcessor<ImageViewAnalysis>, IRecordProcessor
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
