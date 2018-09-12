using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using BookShelf.Backend.Model.Converters;

namespace BookShelf.Backend.Model
{
    public class BookShelf
    {
        [DynamoDBHashKey]
        public string BookShelfId { get; set; }
        [DynamoDBProperty]
        public string Name { get; set; }
        [DynamoDBProperty(Converter = typeof(BookConverter))]
        public List<Book> Books { get; set; }
    }
}