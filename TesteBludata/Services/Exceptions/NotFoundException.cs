using System;

namespace TesteBludata.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message) 
        { 
        }
    }
}
