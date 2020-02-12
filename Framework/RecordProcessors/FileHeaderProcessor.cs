using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class FileHeaderProcessor : RecordProcessor<FileHeader>, IRecordProcessor
	{
		public string RecordType { get; set; } = "01";

        #region Record Bytes

        public virtual int StandardLevelBytes => 2;

        public virtual int TestFileIndicatorBytes => 1;

        public virtual int ImmediateDesignationRoutingNumberBytes => 9;

        public virtual int ImmediateOriginRoutingNumberBytes => 9;

        public virtual int FileHeaderUndefinedRegion1Bytes => 12;

        public virtual int ResendIndicatorBytes => 1;

        public virtual int FileHeaderUndefinedRegion2Bytes => 36;

        public virtual int FileIdModifierBytes => 1;

        #endregion Record Bytes

        public override void Execute()
		{
			base.Execute();

			Parent.FileSpec.FileHeader = Model;
		}

		protected override FileHeader PopulateModel()
		{
            var fileHeader = new FileHeader();

            fileHeader.SpecificationLevel = Parent.X9Reader.ReadBytesAndConvert(StandardLevelBytes);
            fileHeader.TestFileIndicator = Parent.X9Reader.ReadBytesAndConvert(TestFileIndicatorBytes);
            fileHeader.ImmediateDesignationRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(ImmediateDesignationRoutingNumberBytes);
            fileHeader.ImmediateOriginRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(ImmediateOriginRoutingNumberBytes);

            // read undefined bytes from X9 spec
            Parent.X9Reader.ReadBytes(FileHeaderUndefinedRegion1Bytes);

            fileHeader.ResendIndicator = Parent.X9Reader.ReadBytesAndConvert(ResendIndicatorBytes);

            // read undefined bytes from x9 spec
            Parent.X9Reader.ReadBytes(FileHeaderUndefinedRegion2Bytes);

            fileHeader.FileIdModifier = Parent.X9Reader.ReadBytesAndConvert(FileIdModifierBytes);

            return fileHeader;
		}
	}
}
