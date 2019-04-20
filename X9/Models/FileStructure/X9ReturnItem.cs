using System.Collections.ObjectModel;

namespace Tcb.X9.Models.FileStructure
{
	public class X9ReturnItem
	{
		public X9ReturnItem()
		{
			ReturnAddendumAs = new Collection<ReturnAddendumA>();
			ReturnAddendumB = new ReturnAddendumB();
			ReturnAddendumC = new ReturnAddendumC();
			ReturnAddendumDs = new Collection<ReturnAddendumD>();
			ImageViews = new Collection<X9ImageView>();
		}

		public Return Return { get; set; }

		public Collection<ReturnAddendumA> ReturnAddendumAs { get; set; }

		public ReturnAddendumB ReturnAddendumB { get; set; }

		public ReturnAddendumC ReturnAddendumC { get; set; }

		public Collection<ReturnAddendumD> ReturnAddendumDs { get; set; }

		public Collection<X9ImageView> ImageViews { get; set; }
	}
}
