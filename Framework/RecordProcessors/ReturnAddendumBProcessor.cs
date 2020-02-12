using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class ReturnAddendumBProcessor : RecordProcessor<ReturnAddendumB>, IRecordProcessor
	{
		public string RecordType { get; set; } = "33";
        public virtual int UndefinedRegion1Bytes => 18;
        public virtual int AuxiliaryOnUsBytes => 15;

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentReturnItem.ReturnAddendumB = Model;
		}

		protected override ReturnAddendumB PopulateModel()
		{
			var returnAddendumB = new ReturnAddendumB();

            Parent.X9Reader.ReadBytes(UndefinedRegion1Bytes);
            
            returnAddendumB.AuxiliaryOnUs = Parent.X9Reader.ReadBytesAndConvert(AuxiliaryOnUsBytes);

            return returnAddendumB;
		}
	}
}
