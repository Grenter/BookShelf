using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using BookShelf.Lambda.Util;
using BookShelf.Shared.Model;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace BookShelf.Lambda
{
    public class BookFunction
    {
        public APIGatewayProxyResponse GetBooks(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var dbContext = DynamoDbUtil.BuildContext();

            var booksSerch = dbContext.ScanAsync<Book>(new List<ScanCondition>()).GetRemainingAsync();

            var books = booksSerch.Result;

            return ResponseBuilder.Http200(JsonConvert.SerializeObject(books), new Dictionary<string, string> { { "Content-Type", "application/json" } });
        }

        public APIGatewayProxyResponse PostBook(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var book = JsonConvert.DeserializeObject<Book>(request.Body);

            book.Id = Guid.NewGuid().ToString();

            var dbContext = DynamoDbUtil.BuildContext();

            dbContext.SaveAsync(book).Wait();

            var reponse = ResponseBuilder.Http200(book.Id);

            return reponse;
        }
    }
}