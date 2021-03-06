﻿using X9.RecordProcessors;
using X9.RecordProcessors.Abstractions;

namespace X9
{
    public static class TypeToProcessorFactory
	{
		public static IRecordProcessor GetProcessor(string recordType)
		{
			switch (recordType)
			{
				case RecordTypes.FileHeader: return new FileHeaderProcessor();
				case RecordTypes.CashLetterHeader: return new CashLetterHeaderProcessor();
				case RecordTypes.BundleHeader: return new BundleHeaderProcessor();
				case RecordTypes.CheckDetail: return new CheckDetailProcessor();
				case RecordTypes.CheckDetailAddendumA: return new CheckDetailAddendumAProcessor();
				case RecordTypes.CheckDetailAddendumB: return new CheckDetailAddendumBProcessor();
				case RecordTypes.CheckDetailAddendumC: return new CheckDetailAddendumCProcessor();
				case RecordTypes.Return: return new ReturnProcessor();
				case RecordTypes.ReturnAddendumA: return new ReturnAddendumAProcessor();
				case RecordTypes.ReturnAddendumB: return new ReturnAddendumBProcessor();
				case RecordTypes.ReturnAddendumC: return new ReturnAddendumCProcessor();
				case RecordTypes.ReturnAddendumD: return new ReturnAddendumDProcessor();
				case RecordTypes.AccountTotalsDetail: return new AccountTotalsDetailProcessor();
				case RecordTypes.NonHitTotalsDetail: return new NonHitTotalsDetailProcessor();
				case RecordTypes.ImageViewDetail: return new ImageViewDetailProcessor();
				case RecordTypes.ImageViewData: return new ImageViewDataProcessor();
				case RecordTypes.ImageViewAnalysis: return new ImageViewAnalysisProcessor();
				case RecordTypes.BundleControl: return new BundleControlProcessor();
				case RecordTypes.BoxSummary: return new BoxSummaryProcessor();
				case RecordTypes.RoutingNumberSummary: return new RoutingNumberSummaryProcessor();
				case RecordTypes.CashLetterControl: return new CashLetterControlProcessor();
				case RecordTypes.FileControl: return new FileControlProcessor();
				case RecordTypes.CreditReconciliationRecord: return new CreditRecordProcessor();
			}

			return new NullProcessor();
		}
	}
}
