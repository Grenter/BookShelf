using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using BookShelf.Backend.Lambda.Util;
using BookShelf.Backend.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookShelf.Backend.Lambda
{
    public class BookFunction
    {
        public APIGatewayProxyResponse GetBooks(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var dbContext = DynamoDbUtil.BuildContext();

            var shelf = dbContext.CreateBatchGet<Book>();

            return ResponseBuilder.Http200(JsonConvert.SerializeObject(shelf.Results), new Dictionary<string, string> { { "Content-Type", "application/json" } });
        }
    }
}