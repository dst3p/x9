using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcb.X9.Models;

namespace Tcb.X9.RecordProcessors.Interface
{
    public abstract class BaseRecordProcessor<T> where T : X9Record
	{
		protected T Model { get; set; }

		public int ProcessedItems { get; set; }

		public Processor ParentProcessor { get; set; }

		public virtual void Execute()
		{
			Model = PopulateModel();
		}

		protected abstract T PopulateModel();
	}
}
