using System;

namespace X9.Exceptions
{
    public class MissingOnUsException : ChargebackProcessingException
	{
		public MissingOnUsException()
		{
		}

		public MissingOnUsException(string message) : base(message)
		{
		}

		public MissingOnUsException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
