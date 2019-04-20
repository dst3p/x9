using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcb.X9.Exceptions
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
