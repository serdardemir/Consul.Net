using System.Collections.Generic;
using System.Linq;

namespace Consul.Net
{
    public class QueryBuilder
    {
        private readonly string initialQuery;
        private static Dictionary<string, object> query = new Dictionary<string, object>();

        public QueryBuilder()
        {
        }

        public string ToQueryString()
        {
            if (!query.Any() && !string.IsNullOrEmpty(initialQuery)) return initialQuery;

            return !string.IsNullOrEmpty(initialQuery)
                ? $"{initialQuery}&{string.Join("&", query.Select(pair => $"{pair.Key}={pair.Value}").ToArray())}"
                : string.Join("&", query.Select(pair => $"{pair.Key}={pair.Value}").ToArray());
        }
    }
}