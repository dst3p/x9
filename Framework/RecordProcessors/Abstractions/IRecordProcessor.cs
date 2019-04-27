namespace X9.RecordProcessors.Abstractions
{
    public interface IRecordProcessor
	{
		int ProcessedItemCount { get; set; }

		Processor Parent { get; set; }

		void Execute();
	}
}
