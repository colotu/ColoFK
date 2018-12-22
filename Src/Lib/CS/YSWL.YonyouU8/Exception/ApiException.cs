using System;
using System.Collections.Generic;
using System.Text;

namespace YSWL.YonyouU8
{
    public class ApiException: ApplicationException
    {
        public ApiException()
            : base() { }

        public ApiException(string message)
            : base(message) { }

        public ApiException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
