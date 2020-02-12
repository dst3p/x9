using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class CashLetterControlProcessor : RecordProcessor<CashLetterControl>, IRecordProcessor
	{
		public string RecordType { get; set; } = "90";

        public virtual int BundleCountBytes => 6;
        public virtual int CashLetterItemCountBytes => 8;
        public virtual int CashLetterTotalAmountBytes => 14;
        public virtual int CashLetterImageViewCountBytes => 9;
        public virtual int EceInstitutionNameBytes => 18;
        public virtual int SettlementDateBytes => 8;
        public virtual int ReservedBytes => 15;

		public override void Execute()
		{
			base.Execute();

			if (Parent.CurrentCashLetter == null)
			{
				throw new System.Exception("X9 file is malformed or was parsed incorrectly.");
			}

			Parent.CurrentCashLetter.CashLetterControl = Model;

			// Add the cash letter to the file spec
			Parent.FileSpec.CashLetter = Parent.CurrentCashLetter;
		}

		protected override CashLetterControl PopulateModel()
		{
			var cashLetterControl = new CashLetterControl();

            cashLetterControl.BundleCount = Parent.X9Reader.ReadBytesAndConvert(BundleCountBytes);
            cashLetterControl.CashLetterItemCount = Parent.X9Reader.ReadBytesAndConvert(CashLetterItemCountBytes);
            cashLetterControl.CashLetterTotalAmount = Parent.X9Reader.ReadBytesAndConvert(CashLetterTotalAmountBytes);
            cashLetterControl.CashLetterImageViewCount = Parent.X9Reader.ReadBytesAndConvert(CashLetterImageViewCountBytes);
            cashLetterControl.EceInstitutionName = Parent.X9Reader.ReadBytesAndConvert(EceInstitutionNameBytes);
            cashLetterControl.SettlementDate = Parent.X9Reader.ReadBytesAndConvert(SettlementDateBytes);
            cashLetterControl.Reserved = Parent.X9Reader.ReadBytesAndConvert(ReservedBytes);

            return cashLetterControl;
		}
	}
}
