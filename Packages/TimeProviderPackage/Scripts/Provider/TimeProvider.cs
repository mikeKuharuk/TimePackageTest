using System;

namespace TimeProvider
{
    public abstract class TimeProvider
    {
        public abstract DateTime GetTime();
    }
}