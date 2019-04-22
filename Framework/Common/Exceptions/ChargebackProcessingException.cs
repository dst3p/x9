using System;

namespace X9.Exceptions
{
    public class ChargebackProcessingException : Exception
	{
		public ChargebackProcessingException()
		{
		}

		public ChargebackProcessingException(string message) : base(message)
		{
		}

		public ChargebackProcessingException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
