using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class FileHeaderProcessor : RecordProcessor<FileHeader>, IRecordProcessor
    {
        public string RecordType { get; set; } = "01";

        #region Record Bytes

        public virtual int StandardLevelBytes => 2;
        public virtual int FileTypeIndicatorBytes => 1;
        public virtual int ImmediateDesignationRoutingNumberBytes => 9;
        public virtual int ImmediateOriginRoutingNumberBytes => 9;
        public virtual int FileCreationDateBytes => 8;
        public virtual int FileCreationTimeBytes => 4;
        public virtual int ResendIndicatorBytes => 1;
        public virtual int ImmediateDesignationNameBytes => 18;
        public virtual int ImmediateOriginNameBytes => 18;
        public virtual int FileIdModifierBytes => 1;
        public virtual int CountryCodeBytes => 2;
        public virtual int UserFieldBytes => 4;
        public virtual int ReservedBytes => 1;

        #endregion Record Bytes

        public override void Execute()
        {
            base.Execute();

            Parent.FileSpec.FileHeader = Model;
        }

        protected override FileHeader PopulateModel()
        {
            var fileHeader = new FileHeader();

            fileHeader.StandardLevel = Parent.X9Reader.ReadBytesAndConvert(StandardLevelBytes);
            fileHeader.FileTypeIndicator = Parent.X9Reader.ReadBytesAndConvert(FileTypeIndicatorBytes);
            fileHeader.ImmediateDesignationRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(ImmediateDesignationRoutingNumberBytes);
            fileHeader.ImmediateOriginRoutingNumber = Parent.X9Reader.ReadBytesAndConvert(ImmediateOriginRoutingNumberBytes);
            fileHeader.FileCreationDate = Parent.X9Reader.ReadBytesAndConvert(FileCreationDateBytes);
            fileHeader.FileCreationTime = Parent.X9Reader.ReadBytesAndConvert(FileCreationTimeBytes);
            fileHeader.ResendIndicator = Parent.X9Reader.ReadBytesAndConvert(ResendIndicatorBytes);
            fileHeader.ImmediateDesignationName = Parent.X9Reader.ReadBytesAndConvert(ImmediateDesignationNameBytes);
            fileHeader.ImmediateOriginName = Parent.X9Reader.ReadBytesAndConvert(ImmediateOriginNameBytes);
            fileHeader.FileIdModifier = Parent.X9Reader.ReadBytesAndConvert(FileIdModifierBytes);
            fileHeader.CountryCode = Parent.X9Reader.ReadBytesAndConvert(CountryCodeBytes);
            fileHeader.UserField = Parent.X9Reader.ReadBytesAndConvert(UserFieldBytes);
            fileHeader.Reserved = Parent.X9Reader.ReadBytesAndConvert(ReservedBytes);

            return fileHeader;
        }
    }
}
