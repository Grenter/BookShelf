using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using BookShelf.Backend.Lambda.Util;
using BookShelf.Backend.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace BookShelf.Backend.Lambda
{
    public class BookFunction
    {
        public APIGatewayProxyResponse GetBooks(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var dbContext = DynamoDbUtil.BuildContext();

            var booksSerch = dbContext.ScanAsync<Books>(new List<ScanCondition>()).GetRemainingAsync();

            var books = booksSerch.Result;

            return ResponseBuilder.Http200(JsonConvert.SerializeObject(books), new Dictionary<string, string> { { "Content-Type", "application/json" } });
        }
    }
}