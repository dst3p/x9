using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcb.X9.Exceptions
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
