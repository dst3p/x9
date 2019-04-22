using X9.Models;

namespace X9.RecordProcessors.Interface
{
    public abstract class BaseRecordProcessor<T> where T : X9Record
	{
		protected T Model { get; set; }

		public int ProcessedItemCount { get; set; }

		public Processor Parent { get; set; }

		public virtual void Execute()
		{
			Model = PopulateModel();
		}

		protected abstract T PopulateModel();
	}
}
