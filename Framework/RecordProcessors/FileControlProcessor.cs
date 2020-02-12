using X9.Models;
using X9.RecordProcessors.Abstractions;

namespace X9.RecordProcessors
{
    public class FileControlProcessor : RecordProcessor<FileControl>, IRecordProcessor
	{
		public string RecordType { get; set; } = "99";

        public virtual int CashLetterCountBytes => 6;
        public virtual int TotalRecordCountBytes => 8;
        public virtual int TotalItemCountBytes => 8;
        public virtual int FileTotalAmountBytes => 16;
        public virtual int ImmediateOriginContactNameBytes => 14;
        public virtual int ImmediateOriginContactPhoneBytes => 10;
        public virtual int FileCreditTotalAmountBytes => 16;

		public override void Execute()
		{
			base.Execute();

			Parent.FileSpec.FileControl = Model;
		}

		protected override FileControl PopulateModel()
		{
			var fileControl = new FileControl();

            fileControl.CashLetterCount = Parent.X9Reader.ReadBytesAndConvert(CashLetterCountBytes);
            fileControl.TotalRecordCount = Parent.X9Reader.ReadBytesAndConvert(TotalRecordCountBytes);
            fileControl.TotalItemCount = Parent.X9Reader.ReadBytesAndConvert(TotalItemCountBytes);
            fileControl.FileTotalAmount = Parent.X9Reader.ReadBytesAndConvert(FileTotalAmountBytes);
            fileControl.ImmediateOriginContactName = Parent.X9Reader.ReadBytesAndConvert(ImmediateOriginContactNameBytes);
            fileControl.ImmediateOriginContactPhone = Parent.X9Reader.ReadBytesAndConvert(ImmediateOriginContactPhoneBytes);
            fileControl.FileCreditTotalAmount = Parent.X9Reader.ReadBytesAndConvert(FileCreditTotalAmountBytes);

            return fileControl;
		}
	}
}
