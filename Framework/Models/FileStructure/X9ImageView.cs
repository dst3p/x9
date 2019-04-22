namespace X9.Models.FileStructure
{
    public class X9ImageView
	{
		public X9ImageView()
		{
			ImageViewDetail = new ImageViewDetail();
			ImageViewData = new ImageViewData();
			ImageViewAnalysis = new ImageViewAnalysis();
		}

		public ImageViewDetail ImageViewDetail { get; set; }

		public ImageViewData ImageViewData { get; set; }

		public ImageViewAnalysis ImageViewAnalysis { get; set; }
	}
}
