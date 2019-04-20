using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcb.X9.Models.FileStructure
{
	public class X9File
	{
		public X9File()
		{
			FileHeader = new FileHeader();
			CashLetters = new Collection<X9CashLetter>();
			FileControl = new FileControl();
		}

		public FileHeader FileHeader { get; set; }

		public Collection<X9CashLetter> CashLetters { get; set; }

		public FileControl FileControl { get; set; }
	}
}
