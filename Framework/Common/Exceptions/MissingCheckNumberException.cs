using System;

namespace X9.Exceptions
{
    public class MissingCheckNumberException : ChargebackProcessingException
	{
		public MissingCheckNumberException()
		{
		}

		public MissingCheckNumberException(string message) : base(message)
		{
		}

		public MissingCheckNumberException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
