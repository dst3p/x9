using System.Collections.ObjectModel;

namespace X9.Models.FileStructure
{
    public class X9File
	{
		public X9File()
		{
			FileHeader = new FileHeader();
			CashLetter = new X9CashLetter();
			FileControl = new FileControl();
		}

		public FileHeader FileHeader { get; set; }

		public X9CashLetter CashLetter { get; set; }

		public FileControl FileControl { get; set; }
	}
}
