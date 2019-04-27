using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X9.RecordProcessors.Abstractions
{
    public class NullProcessor : IRecordProcessor
    {
        public int ProcessedItemCount { get; set; }

        public Processor Parent { get; set; }

        public void Execute()
        {
            // Empty implementation
        }
    }
}
