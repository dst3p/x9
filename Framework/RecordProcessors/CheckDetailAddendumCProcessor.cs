﻿using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class CheckDetailAddendumCProcessor : RecordProcessor<CheckDetailAddendumC>, IRecordProcessor
	{
		public string RecordType { get; set; } = "28";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentCheckItem.CheckDetailAddendumCs.Add(Model);
		}

		protected override CheckDetailAddendumC PopulateModel()
		{
			return new CheckDetailAddendumC();
		}
	}
}
