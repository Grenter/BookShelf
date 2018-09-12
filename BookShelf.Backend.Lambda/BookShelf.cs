using Amazon.DynamoDBv2.DataModel;

namespace BookShelf.Backend.Lambda
{
    public class BookShelf
    {
        [DynamoDBHashKey]
        public string BookShelfId { get; set; }
        [DynamoDBProperty]
        public string Name { get; set; }
    }
}