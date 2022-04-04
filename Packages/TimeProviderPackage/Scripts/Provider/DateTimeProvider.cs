using System;

namespace TimeProvider
{
    public class DateTimeProvider : TimeProvider
    {
        public override DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}