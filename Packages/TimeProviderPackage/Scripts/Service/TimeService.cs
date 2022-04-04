using System;
using System.Collections.Generic;

namespace TimeProvider
{
    public abstract class GenericTimeService<T> : IGenericTimeService<T> where T : Enum
    {
        protected Dictionary<T, TimeProvider> _timeProviders;

        public virtual DateTime GetTime(T type)
        {
            if (_timeProviders.TryGetValue(type, out var timeProvider))
            {
                return timeProvider.GetTime();
            }
            else
            {
                throw new ArgumentException($"There is no '{type}' provider!");
            }
        }
    }

    public class TimeService : GenericTimeService<ProviderType>, ITimeService
    {
        public TimeService()
        {
            _timeProviders = new Dictionary<ProviderType, TimeProvider>
            {
                {ProviderType.DateTime, new DateTimeProvider()},
                {ProviderType.Ntc, new NTCProvider()}
            };
        }
    }

    public enum ProviderType
    {
        DateTime,
        Ntc,
    }
}