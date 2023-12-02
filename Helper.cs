using Amazon;
using Amazon.DynamoDBv2;
using Amazon.S3;
using Microsoft.Extensions.Options;
using System.Configuration;


namespace Api_Project
{
    public static class Helper
    {
    
       // public readonly static IConfiguration _configuration;
        public readonly static IAmazonS3 s3Client;
        public readonly static AmazonDynamoDBClient dynamoDBClient;
         static Helper()
        {
   
            dynamoDBClient = GetDynamoDBClient();
        }

   

        private static AmazonDynamoDBClient GetDynamoDBClient()
        {
            //string accessKey = _configuration["AWS:accessId"];
            //string awsSecretKey = _configuration["AWS:password"];
            try
            {
                //return new AmazonDynamoDBClient(accessKey, awsSecretKey, RegionEndpoint.CACentral1);
                return new AmazonDynamoDBClient("AKIAUTK6B5DCEDVEBN7Q", "Nt2ewgBPhdGKDcG7lKwN+2cqUIhBGqnHSampWZCf", RegionEndpoint.CACentral1);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
    }
}
