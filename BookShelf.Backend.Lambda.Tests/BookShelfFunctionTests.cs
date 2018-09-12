using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using BookShelf.Backend.Model;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace BookShelf.Backend.Lambda.Tests
{
    [TestFixture]
    public class BookShelfFunctionTests
    {
        [Test]
        public void Should_return_a_book()
        {
            InsertDummyRecordIntoLocalDb();

            var bookShelfFunction = new ShelfFunction();

            var response = bookShelfFunction.Get(Substitute.For<APIGatewayProxyRequest>(), Substitute.For<ILambdaContext>());

            var bookJson = JsonConvert.DeserializeObject<Book>(response.Body);

            Assert.That(bookJson.Title, Is.EqualTo("Test-Title"));
        }

        private void InsertDummyRecordIntoLocalDb()
        {
            throw new System.NotImplementedException();
        }
    }
}
