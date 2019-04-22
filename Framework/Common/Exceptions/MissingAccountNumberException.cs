using System;

namespace X9.Exceptions
{
    public class MissingAccountNumberException : ChargebackProcessingException
	{
		public MissingAccountNumberException()
		{
		}

		public MissingAccountNumberException(string message) : base(message)
		{
		}

		public MissingAccountNumberException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
