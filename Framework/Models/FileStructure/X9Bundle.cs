using System.Collections.ObjectModel;
using X9.Common;

namespace X9.Models.FileStructure
{
    public class X9Bundle
	{
		public X9Bundle()
		{
			BundleHeader = new BundleHeader();
			CheckItems = new Collection<X9ForwardPresentmentItem>();
			ReturnItems = new Collection<X9ReturnItem>();
			BundleControl = new BundleControl();
			BoxSummary = new BoxSummary();
		}

		public BundleType BundleType { get; set; }

		public BundleHeader BundleHeader { get; set; }

		public Collection<X9ForwardPresentmentItem> CheckItems { get; set; }

		public Collection<X9ReturnItem> ReturnItems { get; set; }

		public BundleControl BundleControl { get; set; }

		public BoxSummary BoxSummary { get; set; }
	}
}
