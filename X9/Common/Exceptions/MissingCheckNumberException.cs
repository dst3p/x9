using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcb.X9.Exceptions
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
