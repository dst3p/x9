using X9.Common;
using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class BundleControlProcessor : RecordProcessor<BundleControl>, IRecordProcessor
	{
		public string RecordType { get; set; } = "70";

        public virtual int UndefinedRegion1Bytes => 16;
        public virtual int MicrValidTotalAmountBytes => 12;

		public override void Execute()
		{
			AddLastItemToBundle();

			base.Execute();

			if (Parent.CurrentBundle == null)
			{
				throw new System.Exception("X9 was malformed or parsed incorrectly");
			}

			Parent.CurrentBundle.BundleControl = Model;
			Parent.CurrentCashLetter.Bundles.Add(Parent.CurrentBundle);
		}

		protected override BundleControl PopulateModel()
		{
			var bundleControl = new BundleControl();

            bundleControl.UndefinedRegion = Parent.X9Reader.ReadBytesAndConvert(UndefinedRegion1Bytes);
            bundleControl.MicrValidTotalAmount = Parent.X9Reader.ReadBytesAndConvert(MicrValidTotalAmountBytes);

            return bundleControl;
		}

		private void AddLastItemToBundle()
		{
			if (Parent.CurrentBundle.BundleType == BundleType.ForwardPresentment)
			{
				Parent.CurrentBundle.CheckItems.Add(Parent.CurrentCheckItem);
			}

			if (Parent.CurrentBundle.BundleType == BundleType.Return)
			{
				Parent.CurrentBundle.ReturnItems.Add(Parent.CurrentReturnItem);
			}
		}
	}
}
