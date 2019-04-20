using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcb.X9.Exceptions
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
