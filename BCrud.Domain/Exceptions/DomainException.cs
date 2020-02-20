using System;
using System.Collections.Generic;
using System.Text;

namespace BCrud.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string msg) : base(msg)
        { }
    }
}
