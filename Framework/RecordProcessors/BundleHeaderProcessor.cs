using X9.Models;
using X9.Models.FileStructure;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class BundleHeaderProcessor : RecordProcessor<BundleHeader>, IRecordProcessor
	{
		public string RecordType { get; set; } = "20";

        public virtual int CollectionTypeIndicatorBytes => 2;
        public virtual int BundleDestinationRoutingNumberBytes => 9;
        public virtual int BundleClientInstitutionRoutingNumberBytes => 9;
        public virtual int BundleBusinessDateBytes => 8;
        public virtual int BundleCreationDateBytes => 8;
        public virtual int BundleIdBytes => 10;
        public virtual int BundleSequenceNumberBytes => 4;
        public virtual int CycleNumberBytes => 2;
        public virtual int ReturnLocationRoutingNumberBytes => 9;
        public virtual int UndefinedRegion1Bytes => 16;
        public virtual int UndefinedRegion2Bytes => 2;
        public virtual int UserFieldBytes => 5;
        public virtual int ReservedBytes => 12;

		public override void Execute()
		{
			base.Execute();

			Parent.CurrentBundle = new X9Bundle
			{
				BundleHeader = Model
			};
		}

		protected override BundleHeader PopulateModel()
		{
			var bundleHeader = new BundleHeader();

            bundleHeader.CollectionTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(CollectionTypeIndicatorBytes);
            bundleHeader.BundleDestinationRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(BundleDestinationRoutingNumberBytes);
            bundleHeader.BundleClientInstitutionRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(BundleClientInstitutionRoutingNumberBytes);
            bundleHeader.BundleBusinessDate = Parent.X9Reader.ReadBytesAndConvert(BundleBusinessDateBytes);
            bundleHeader.BundleCreationDate = Parent.X9Reader.ReadBytesAndConvert(BundleCreationDateBytes);
            bundleHeader.BundleId = Parent.X9Reader.ReadBytesAndConvert(BundleIdBytes);
            bundleHeader.BundleSequenceNumber = Parent.X9Reader.ReadBytesAndConvert(BundleSequenceNumberBytes);
            bundleHeader.CycleNumber = Parent.X9Reader.ReadBytesAndConvert(CycleNumberBytes);
            bundleHeader.ReturnLocationRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(ReturnLocationRoutingNumberBytes);
            bundleHeader.UserField = Parent.X9Reader.ReadBytesAndConvert(UserFieldBytes);
            bundleHeader.Reserved = Parent.X9Reader.ReadBytesAndConvert(ReservedBytes);

            return bundleHeader;
		}
	}
}
