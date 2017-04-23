using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany.Exceptions
{
    public class NoDataChangedException : Exception
    {
        private const string DEFAULT_MESSAGE = "No data were changed in database.";
        public NoDataChangedException() : base(DEFAULT_MESSAGE)
        {

        }

        public NoDataChangedException(string message)
            : base(message)
        {

        }

        public NoDataChangedException(string message, Exception inner)
            : base(message, inner)
        {

        }

        public NoDataChangedException(Exception inner)
            : base(DEFAULT_MESSAGE, inner)
        {

        }
    }
}
