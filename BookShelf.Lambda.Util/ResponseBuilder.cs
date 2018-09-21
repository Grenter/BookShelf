using System.Collections.Generic;
using System.Net;
using Amazon.Lambda.APIGatewayEvents;

namespace BookShelf.Lambda.Util
{
    public class ResponseBuilder
    {
        public static APIGatewayProxyResponse Build(HttpStatusCode status, string body, IDictionary<string, string> headers)
        {
            var allHeaders = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain" },
                { "Access-Control-Allow-Origin", "*" }
            };

            foreach (var header in headers)
            {
                if (allHeaders.ContainsKey(header.Key))
                {
                    allHeaders[header.Key] = header.Value;
                }
                else
                {
                    allHeaders.Add(header.Key, header.Value);
                }
            }

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)status,
                Body = body,
                Headers = allHeaders
            };
        }

        public static APIGatewayProxyResponse Build(HttpStatusCode status, string body)
        {
            return Build(status, body, new Dictionary<string, string>());
        }

        public static APIGatewayProxyResponse Http200(string body, IDictionary<string, string> headers = null)
        {
            return headers is null
                ? Build(HttpStatusCode.OK, body)
                : Build(HttpStatusCode.OK, body, headers);
        }
    }
}
