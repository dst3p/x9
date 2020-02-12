using X9.Common;
using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class BundleControlProcessor : RecordProcessor<BundleControl>, IRecordProcessor
	{
		public string RecordType { get; set; } = "70";
        public virtual int BundleItemCountBytes => 4;
        public virtual int BundleTotalAmountBytes => 12;
        public virtual int MicrValidTotalAmountBytes => 12;
        public virtual int ImagesWithinBundleCountBytes => 5;
        public virtual int UserFieldBytes => 20;
        public virtual int ReservedBytes => 25;

		public override void Execute()
		{
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

            bundleControl.BundleItemCount = Parent.X9Reader.ReadBytesAndConvert(BundleItemCountBytes);
            bundleControl.BundleTotalAmount = Parent.X9Reader.ReadBytesAndConvert(BundleTotalAmountBytes);
            bundleControl.MicrValidTotalAmount = Parent.X9Reader.ReadBytesAndConvert(MicrValidTotalAmountBytes);
            bundleControl.ImagesWithinBundleCount = Parent.X9Reader.ReadBytesAndConvert(ImagesWithinBundleCountBytes);
            bundleControl.UserField = Parent.X9Reader.ReadBytesAndConvert(UserFieldBytes);
            bundleControl.Reserved = Parent.X9Reader.ReadBytesAndConvert(ReservedBytes);
            
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
