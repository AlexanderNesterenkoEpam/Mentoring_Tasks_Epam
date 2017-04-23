using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany.Exceptions
{
    public class OpenConnectionException : Exception
    {
        private const string DEFAULT_MESSAGE = "An error occurred while opening the connection.";
        public OpenConnectionException() : base(DEFAULT_MESSAGE)
        {

        }

        public OpenConnectionException(string message)
            : base(message)
        {

        }

        public OpenConnectionException(string message, Exception inner)
            : base(message, inner)
        {

        }

        public OpenConnectionException(Exception inner) : base(DEFAULT_MESSAGE, inner)
        {

        }
    }
}
