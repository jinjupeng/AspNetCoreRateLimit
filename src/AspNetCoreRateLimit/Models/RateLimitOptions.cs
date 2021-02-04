using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreRateLimit
{
    /// <summary>
    /// 限流参数实体（映射限流规则参数）
    /// </summary>
    public class RateLimitOptions
    {
        /// <summary>
        /// 通用限流规则
        /// </summary>
        public List<RateLimitRule> GeneralRules { get; set; }

        /// <summary>
        /// 终结点白名单
        /// </summary>
        public List<string> EndpointWhitelist { get; set; }

        /// <summary>
        /// Gets or sets the HTTP header that holds the client identifier, by default is X-ClientId
        /// </summary>
        public string ClientIdHeader { get; set; } = "X-ClientId";

        /// <summary>
        /// 客户端白名单
        /// </summary>
        public List<string> ClientWhitelist { get; set; }

        /// <summary>
        /// Gets or sets the HTTP header of the real ip header injected by reverse proxy, by default is X-Real-IP
        /// </summary>
        public string RealIpHeader { get; set; } = "X-Real-IP";

        /// <summary>
        /// ip白名单
        /// </summary>
        public List<string> IpWhitelist { get; set; }

        /// <summary>
        /// Gets or sets the HTTP Status code returned when rate limiting occurs, by default value is set to 429 (Too Many Requests)
        /// </summary>
        public int HttpStatusCode { get; set; } = 429;

        /// <summary>
        /// Gets or sets a value that will be used as a formatter for the QuotaExceeded response message.
        /// If none specified the default will be: 
        /// API calls quota exceeded! maximum admitted {0} per {1}
        /// 限额超出警告信息
        /// </summary>
        public string QuotaExceededMessage { get; set; }

        /// <summary>
        /// Gets or sets a model that represents the QuotaExceeded response (content-type, content, status code).
        /// </summary>
        public QuotaExceededResponse QuotaExceededResponse { get; set; }

        /// <summary>
        /// Gets or sets the counter prefix, used to compose(组成构成) the rate limit counter cache key
        /// </summary>
        public string RateLimitCounterPrefix { get; set; } = "crlc";

        /// <summary>
        /// Gets or sets a value indicating（表明、暗示、象征） whether all requests, including the rejected ones, should be stacked in this order: day, hour, min, sec
        /// </summary>
        public bool StackBlockedRequests { get; set; }

        /// <summary>
        /// Enables endpoint rate limiting based URL path and HTTP verb
        /// </summary>
        public bool EnableEndpointRateLimiting { get; set; }

        /// <summary>
        /// Disables X-Rate-Limit and Rety-After headers
        /// </summary>
        public bool DisableRateLimitHeaders { get; set; }

        /// <summary>
        /// Enabled the comparison logic to use Regex instead of wildcards.
        /// </summary>
        public bool EnableRegexRuleMatching { get; set; }

        /// <summary>
        /// Gets or sets behavior after the request is blocked
        /// </summary>
        public Func<HttpContext, ClientRequestIdentity, RateLimitCounter, RateLimitRule, Task> RequestBlockedBehaviorAsync { get; set; }
    }
}