using System;
using MongoDB.Driver;

namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {

            var databaseName = "sampledb";
            var connectionString = "mongodb://Mahone_1985:7f2AHeK06ScpAePs@sampledb-shard-00-02.egd8v.mongodb.net:27017/";
            var client = new MongoClient(connectionString + databaseName);



        }
    }
}
