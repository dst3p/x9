using MiscUtil.Conversion;
using System.IO;
using System.Text;
using X9.Common.Extensions;

namespace X9
{
    public class X9BinaryReader : BinaryReader
	{
		/// <summary>
		/// The number of bytes to read to get the record length.
		/// </summary>
		public virtual int RecordLengthNumBytes => 4;

		/// <summary>
		/// Tracks the starting position of the current record being processed.
		/// </summary>
		public long CurrentRecordStartPosition { get; set; }

		/// <summary>
		/// Value indicating the length of the record before reading the first 4 bytes.
		/// </summary>
		public long CurrentRecordBaseLength
		{
			get
			{
				return CurrentRecordLength + RecordLengthNumBytes;
			}
		}

		/// <summary>
		///  Value indicating the length of the record after reading the first 4 bytes.
		/// </summary>
		public long CurrentRecordLength { get; set; }

		#region Constructors

		public X9BinaryReader(Stream input) : base(input)
		{
		}

		public X9BinaryReader(Stream input, Encoding encoding) : base(input, encoding)
		{
		}

		public X9BinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
		{
		}

		#endregion Constructors

		/// <summary>
		/// Gets the detail of the next record in the file. Sets the <see cref="CurrentRecordStartPosition"/>
		/// field to the <see cref="X9BinaryReader"/>'s BaseStream.Position value. Also gets the length of
		/// the current record by reading 4 bytes and then converting those using
		/// <see cref="BigEndianBitConverter"/>.
		/// </summary>
		public X9BinaryReader GetNext()
		{
			// Track the starting position and length of each record for easier writing to file
			CurrentRecordStartPosition = BaseStream.Position;

			var recordLengthBytes = ReadBytes(RecordLengthNumBytes);

			CurrentRecordLength = new BigEndianBitConverter().ToInt32(recordLengthBytes, 0);

            return this;
		}

		/// <summary>
		/// Reads a full record by finding the position in the stream using
		/// <see cref="CurrentRecordStartPosition"/> and reading the number of bytes
		/// specified in <see cref="CurrentRecordBaseLength"/>.
		/// </summary>
		/// <returns>A byte array representing the full record.</returns>
		private byte[] ReadFullRecordBytes()
		{
			BaseStream.Seek(CurrentRecordStartPosition, SeekOrigin.Begin);
			return ReadBytes((int)CurrentRecordBaseLength);
		}

		/// <summary>
		/// Move to the next record by finding the position in the stream using
		/// <see cref="CurrentRecordStartPosition"/> and reading the number of bytes
		/// specified in <see cref="CurrentRecordBaseLength"/>. 
		/// </summary>
		public X9BinaryReader MoveNext()
		{
			ReadFullRecordBytes();

            return this;
		}

		/// <summary>
		/// Read bytes from the <see cref="X9BinaryReader"/> stream and convert those bytes
		/// directly to ASCII.
		/// </summary>
		/// <param name="byteCount">The number of bytes to read from the stream.</param>
		/// <returns>An ASCII string represenation of the bytes read from the stream.</returns>
		public string ReadBytesAndConvert(int byteCount)
		{
			//CurrentRecordBytesRead += byteCount;

			var bytes = ReadBytes(byteCount);

			return bytes.BytesToASCII();
		}
	}
}
