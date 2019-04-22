using X9.Common;
using X9.Models;
using X9.Models.FileStructure;
using X9.RecordProcessors.Interface;

namespace X9.RecordProcessors
{
    public class CheckDetailProcessor : BaseRecordProcessor<CheckDetail>, ITypeProcessor
	{
		public string RecordType { get; set; } = "25";

		public override void Execute()
		{
			if (Parent.CurrentCheckItem != null)
			{
				Parent.CurrentBundle.CheckItems.Add(Parent.CurrentCheckItem);
			}

			base.Execute();

			Parent.CurrentCheckItem = new X9ForwardPresentmentItem
			{
				CheckDetail = Model
			};

			Parent.CurrentBundle.BundleType = BundleType.ForwardPresentment;
		}

		protected override CheckDetail PopulateModel()
		{
			return new CheckDetail();
		}
	}
}
