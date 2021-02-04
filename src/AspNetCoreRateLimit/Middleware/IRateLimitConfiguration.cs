using System;
using System.Collections.Generic;

namespace AspNetCoreRateLimit
{
    /// <summary>
    /// 限流配置接口
    /// </summary>
    public interface IRateLimitConfiguration
    {
        IList<IClientResolveContributor> ClientResolvers { get; }

        IList<IIpResolveContributor> IpResolvers { get; }

        ICounterKeyBuilder EndpointCounterKeyBuilder { get; }

        Func<double> RateIncrementer { get; }

        void RegisterResolvers();
    }
}