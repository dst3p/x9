﻿using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class NonHitTotalsDetailProcessor : RecordProcessor<NonHitTotalsDetail>, IRecordProcessor
	{
		public string RecordType { get; set; } = "41";

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentCashLetter.NonHitTotalsDetails.Add(Model);
		}

		protected override NonHitTotalsDetail PopulateModel()
		{
			return new NonHitTotalsDetail();
		}
	}
}
