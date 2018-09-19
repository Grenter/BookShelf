using System;
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

        public APIGatewayProxyResponse PostBook(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var book = JsonConvert.DeserializeObject<Books>(request.Body);

            book.BookId = Guid.NewGuid().ToString();

            var dbContext = DynamoDbUtil.BuildContext();

            dbContext.SaveAsync(book).Wait();

            var reponse = ResponseBuilder.Http200(book.BookId);

            return reponse;
        }
    }
}