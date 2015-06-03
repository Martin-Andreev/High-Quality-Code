using System;

namespace Theatre.Exceptions
{
    public class TimeDurationOverlapException : ApplicationException
    {
        public TimeDurationOverlapException(string msg)
            : base(msg)
        {
        }
    }
}