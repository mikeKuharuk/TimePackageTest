using System;

namespace TimeProvider
{
    public interface IGenericTimeService<T> where T : Enum
    {
        DateTime GetTime(T type);
    }

    public interface ITimeService : IGenericTimeService<ProviderType>
    {
        new DateTime GetTime(ProviderType type);
    }
}