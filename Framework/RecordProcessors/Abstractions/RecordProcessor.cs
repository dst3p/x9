using X9.Models;

namespace X9.RecordProcessors.Abstractions
{
    public abstract class RecordProcessor<T> : IRecordProcessor where T : X9Record
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
