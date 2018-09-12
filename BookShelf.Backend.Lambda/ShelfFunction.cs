using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using BookShelf.Backend.Lambda.Util;
using Newtonsoft.Json;
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

            var dbContext = DynamoDbUtil.BuildContext();

            var shelfId = qryParams["shelfId"];

            var shelf = dbContext.LoadAsync<Model.BookShelf>(shelfId);

            context.Logger.LogLine(shelf.Result.Name);

            return ResponseBuilder.Http200(JsonConvert.SerializeObject(shelf), new Dictionary<string, string> { { "Content-Type", "application/json" } });

        }
    }
}
