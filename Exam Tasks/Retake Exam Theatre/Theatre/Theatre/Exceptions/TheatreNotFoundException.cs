using System;

namespace Theatre.Exceptions
{
    public class TheatreNotFoundException : ApplicationException
    {
        public TheatreNotFoundException(string msg)
            : base(msg)
        {
        }
    }
}