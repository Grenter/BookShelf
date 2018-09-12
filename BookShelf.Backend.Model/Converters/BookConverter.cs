using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Newtonsoft.Json;

namespace BookShelf.Backend.Model.Converters
{
    public class BookConverter : IPropertyConverter
    {
        public DynamoDBEntry ToEntry(object value)
        {
            var book = value as Book;
            if (book == null) return null;

            var json = JsonConvert.SerializeObject(book);
            return new Primitive(json);
        }

        public object FromEntry(DynamoDBEntry entry)
        {
            var primitive = entry as Primitive;
            if (primitive == null) return new List<Book>();

            if (primitive.Type != DynamoDBEntryType.String)
            {
                throw new InvalidCastException($"Book cannot be converted as its type is {primitive.Type} with a value of {primitive.Value}");
            }

            var json = primitive.AsString();
            return JsonConvert.DeserializeObject<List<Book>>(json);
        }
    }
}