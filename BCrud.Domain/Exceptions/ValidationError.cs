using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Domain.Exceptions
{
    public class ValidationError : Exception
    {
        public ValidationError(string msg) : base(msg)
        { }
    }
}
