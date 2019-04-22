namespace X9.RecordProcessors.Interface
{
    public interface ITypeProcessor
	{
		string RecordType { get; set; }

		int ProcessedItemCount { get; set; }

		Processor Parent { get; set; }

		void Execute();
	}
}
