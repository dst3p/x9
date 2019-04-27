using System.IO;
using X9.Models.FileStructure;

namespace X9
{
    public class Processor
    {
        public X9File FileSpec { get; set; } = new X9File();

        public X9CashLetter CurrentCashLetter;

        public X9Bundle CurrentBundle;

        public X9ReturnItem CurrentReturnItem;

        public X9ForwardPresentmentItem CurrentCheckItem;

        public X9ImageView CurrentImage;

        public int RecordTypeNumBytes => 2;

        public virtual X9BinaryReader X9Reader { get; set; }

        public virtual void Execute(FileStream inputStream)
        {
            using (X9Reader = new X9BinaryReader(inputStream))
            {
                try
                {
                    X9Reader.GetNext();

                    while (true)
                    {
                        // Get record type
                        var recordType = X9Reader.ReadBytesAndConvert(RecordTypeNumBytes);

                        var processor = TypeToProcessorFactory.GetProcessor(recordType);

                        processor.Parent = this;
                        processor.Execute();

                        // exit after processing file control
                        if (recordType == RecordTypes.FileControl)
                        {
                            break;
                        }

                        X9Reader.MoveNext().GetNext();
                    }
                }
                catch (EndOfStreamException end)
                {
                    //    return "Unexpectedly reached end of stream. " + end.Message;
                    //}
                    //catch (Exception e)
                    //{
                    //    return "An unhandled exception occurred. " + e.Message;
                }
            }
        }
    }
}
