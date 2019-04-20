﻿using System;
using System.IO;
using Tcb.X9.Interfaces;
using Tcb.X9.Models.FileStructure;
using Tcb.X9.RecordProcessors;
using Tcb.X9.RecordProcessors.Interface;
using Tcb.X9.X937;

namespace Tcb.X9
{
    public abstract class Processor : IX9File, IX9ForwardPresentment, IX9Return
    {
        public X9File FileSpec { get; set; } = new X9File();

        public X9CashLetter CurrentCashLetter;

        public X9Bundle CurrentBundle;

        public X9ReturnItem CurrentReturnItem;

        public X9ForwardPresentmentItem CurrentCheckItem;

        public X9ImageView CurrentImage;

        public virtual int RecordTypeNumBytes => 2;

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

                        IBaseProcessor recordProcessor = TypeToProcessorMapper.GetProcessor(recordType);

                        if (recordProcessor != null)
                        {
                            recordProcessor.ParentProcessor = this;
                            recordProcessor.Execute();
                        }

                        // exit after processing file control
                        if (recordType == RecordTypes.FileControl)
                        {
                            break;
                        }

                        X9Reader.MoveNext();
                        X9Reader.GetNext();
                    }
                }
                catch (EndOfStreamException end)
                {
                    //return "Unexpectedly reached end of stream. " + end.Message;
                }
                //catch (Exception e)
                //{
                //	return "An unhandled exception occurred. " + e.Message;
                //}
            }
        }

        public virtual void ProcessReturn()
        {
            var returnProcessor = new ReturnProcessor();

            returnProcessor.Execute();
        }

        public virtual void ProcessReturnAddendumA()
        {
            throw new NotImplementedException();
        }

        public virtual void ProcessReturnAddendumB()
        {
            throw new NotImplementedException();
        }

        public virtual void ProcessReturnAddendumD()
        {
            throw new NotImplementedException();
        }

        public void ProcessFileHeader()
        {
            var fileHeaderProcessor = new FileHeaderProcessor();

            fileHeaderProcessor.Execute();
        }

        public void ProcessCashLetterHeader()
        {
            throw new NotImplementedException();
        }

        public void ProcessBundleHeader()
        {
            throw new NotImplementedException();
        }

        public void ProcessImageViewDetail()
        {
            throw new NotImplementedException();
        }

        public void ProcessImageViewData()
        {
            throw new NotImplementedException();
        }

        public void ProcessImageViewAnalysis()
        {
            throw new NotImplementedException();
        }

        public void ProcessBundleControl()
        {
            throw new NotImplementedException();
        }

        public void ProcessCashLetterControl()
        {
            throw new NotImplementedException();
        }

        public void ProcessFileControl()
        {
            throw new NotImplementedException();
        }

        public void ProcessCheckDetail()
        {
            throw new NotImplementedException();
        }

        public void ProcessCheckDetailAddendumA()
        {
            throw new NotImplementedException();
        }

        public void ProcessCheckDetailAddendumC()
        {
            throw new NotImplementedException();
        }
    }
}