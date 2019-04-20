using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcb.X9.Models;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9.RecordProcessors
{
	public class FileHeaderProcessor : BaseRecordProcessor<FileHeader>, IBaseProcessor
	{
		public string RecordType { get; set; } = "01";

		public override void Execute()
		{
			base.Execute();

			ParentProcessor.FileSpec.FileHeader = Model;
		}

		protected override FileHeader PopulateModel()
		{
			return new FileHeader();
		}
	}
}
