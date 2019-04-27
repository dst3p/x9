﻿using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ReturnAddendumBProcessor : RecordProcessor<ReturnAddendumB>, IRecordProcessor
	{
		public string RecordType { get; set; } = "33";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentReturnItem.ReturnAddendumB = Model;
		}

		protected override ReturnAddendumB PopulateModel()
		{
			return new ReturnAddendumB();
		}
	}
}
