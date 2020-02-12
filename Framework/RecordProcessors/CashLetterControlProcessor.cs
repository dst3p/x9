using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class CashLetterControlProcessor : RecordProcessor<CashLetterControl>, IRecordProcessor
	{
		public string RecordType { get; set; } = "90";

        public virtual int UndefinedRegionBytes => 55;
        public virtual int SettlementDateBytes => 8;

		public override void Execute()
		{
			base.Execute();

			if (Parent.CurrentCashLetter == null)
			{
				throw new System.Exception("X9 file is malformed or was parsed incorrectly.");
			}

			Parent.CurrentCashLetter.CashLetterControl = Model;

			// Add the cash letter to the file spec
			Parent.FileSpec.CashLetters.Add(Parent.CurrentCashLetter);
		}

		protected override CashLetterControl PopulateModel()
		{
			var cashLetterControl = new CashLetterControl();

            cashLetterControl.UndefinedRegion = Parent.X9Reader.ReadBytesAndConvert(UndefinedRegionBytes);
            cashLetterControl.SettlementDate = Parent.X9Reader.ReadBytesAndConvert(SettlementDateBytes);

            return cashLetterControl;
		}
	}
}
