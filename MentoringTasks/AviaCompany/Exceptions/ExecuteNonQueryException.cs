using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany.Exceptions
{
    public class ExecuteNonQueryException : Exception
    {
        private const string DEFAULT_MESSAGE = "An error occurred while execute non query operation.";
        public ExecuteNonQueryException() : base(DEFAULT_MESSAGE)
        {

        }

        public ExecuteNonQueryException(string message)
            : base(message)
        {

        }

        public ExecuteNonQueryException(string message, Exception inner)
            : base(message, inner)
        {

        }

        public ExecuteNonQueryException(Exception inner)
            : base(DEFAULT_MESSAGE, inner)
        {

        }
    }
}
