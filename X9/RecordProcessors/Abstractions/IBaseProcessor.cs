namespace Tcb.X9.RecordProcessors.Interface
{
    public interface IBaseProcessor
	{
		string RecordType { get; set; }

		int ProcessedItems { get; set; }

		Processor ParentProcessor { get; set; }

		void Execute();
	}
}
