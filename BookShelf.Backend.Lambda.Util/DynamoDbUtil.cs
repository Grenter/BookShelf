using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using System;

namespace BookShelf.Backend.Lambda.Util
{
    public static class DynamoDbUtil
    {
        private static AmazonDynamoDBClient _client;

        public static DynamoDBContext BuildContext()
        {
            return new DynamoDBContext(GetClient());
        }

        private static AmazonDynamoDBClient GetClient()
        {
            return GetClient(Environment.GetEnvironmentVariable("AccessKey"), Environment.GetEnvironmentVariable("SecretKey"));
        }

        private static AmazonDynamoDBClient GetClient(string accessKey, string secretKey, RegionEndpoint endpoint = null)
        {
            if (endpoint is null) endpoint = RegionEndpoint.EUWest2;

            return _client ?? (_client = new AmazonDynamoDBClient(new BasicAWSCredentials(accessKey, secretKey), endpoint));
        }
    }
}
