﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcb.X9.Models.FileStructure
{
	public class X9ForwardPresentmentItem
	{
		public X9ForwardPresentmentItem()
		{
			CheckDetail = new CheckDetail();
			CheckDetailAddendumAs = new Collection<CheckDetailAddendumA>();
			CheckDetailAddendumB = new CheckDetailAddendumB();
			CheckDetailAddendumCs = new Collection<CheckDetailAddendumC>();
			ImageViews = new Collection<X9ImageView>();
		}

		public CheckDetail CheckDetail { get; set; }

		public Collection<CheckDetailAddendumA> CheckDetailAddendumAs { get; set; }

		public CheckDetailAddendumB CheckDetailAddendumB { get; set; }

		public Collection<CheckDetailAddendumC> CheckDetailAddendumCs { get; set; }

		public Collection<X9ImageView> ImageViews { get; set; }
	}
}
