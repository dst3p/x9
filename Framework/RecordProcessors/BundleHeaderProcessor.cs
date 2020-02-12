using X9.Models;
using X9.Models.FileStructure;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class BundleHeaderProcessor : RecordProcessor<BundleHeader>, IRecordProcessor
	{
		public string RecordType { get; set; } = "20";

        public virtual int CollectionTypeIndicatorBytes => 2;
        public virtual int DestinationRoutingNumberBytes => 9;
        public virtual int EceInstitutionRoutingNumberBytes => 9;
        public virtual int BundleIdBytes => 10;
        public virtual int BundleSequenceNumberBytes => 4;
        public virtual int ReturnLocationRoutingNumberBytes => 9;
        public virtual int UndefinedRegion1Bytes => 16;
        public virtual int UndefinedRegion2Bytes => 2;

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
            bundleHeader.DestinationRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(DestinationRoutingNumberBytes);
            bundleHeader.EceInstitutionRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(EceInstitutionRoutingNumberBytes);

            Parent.X9Reader.ReadBytes(UndefinedRegion1Bytes);

            bundleHeader.BundleId = Parent.X9Reader.ReadBytesAndConvert(BundleIdBytes);
            bundleHeader.BundleSequenceNumber = Parent.X9Reader.ReadBytesAndConvert(BundleSequenceNumberBytes);
            
            Parent.X9Reader.ReadBytes(UndefinedRegion2Bytes);

            bundleHeader.ReturnLocationRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(ReturnLocationRoutingNumberBytes);

            return bundleHeader;
		}
	}
}
