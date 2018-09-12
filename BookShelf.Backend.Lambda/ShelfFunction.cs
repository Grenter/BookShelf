using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Runtime;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace BookShelf.Backend.Lambda
{
    public class ShelfFunction
    {
        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var qryParams = request.QueryStringParameters;

            context.Logger.LogLine(string.Join(',', qryParams.Keys));

            var dbContext = new DynamoDBContext(new AmazonDynamoDBClient(new BasicAWSCredentials(Environment.GetEnvironmentVariable("AccessKey"), Environment.GetEnvironmentVariable("SecretKey")), RegionEndpoint.EUWest2));

            var shelfId = qryParams["shelfId"];

            var shelf = dbContext.LoadAsync<BookShelf>(shelfId);

            context.Logger.LogLine(shelf.Result.Name);

            return new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = JsonConvert.SerializeObject(shelf),
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "text/plain" },
                    { "Access-Control-Allow-Origin", "*" }
                }
            };
        }
    }
}
