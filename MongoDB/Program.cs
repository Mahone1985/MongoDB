using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {

            //var databaseName = "sampledb";
            //var connectionString = "mongodb://Mahone_1985:7f2AHeK06ScpAePs@sampledb-shard-00-02.egd8v.mongodb.net:27017/";
            //var client = new MongoClient(connectionString + databaseName);

            //var GetTypeVar = client.GetType();
            //Console.WriteLine("collection = {0}", GetTypeVar);

            //var ClusterIdVar = client.Cluster.ClusterId.ToString();
            //Console.WriteLine("collection = {0}", ClusterIdVar);

            //var ListDatabasesVar = client.GetDatabase(databaseName);
            //Console.WriteLine("collection = {0}", ListDatabasesVar);

            //var dbList = client.ListDatabaseNames().ToList();

            //Console.WriteLine("The list of databases on this server is: ");
            //foreach (var db in dbList)
            //{
            //    Console.WriteLine(db);
            //}

            //var dbList = client.ListDatabases().ToList();

            //Console.WriteLine("The list of databases on this server is: ");
            //foreach (var db in dbList)
            //{
            //    Console.WriteLine(db);
            //}

            //var GetTypeVar = client.GetType();
            //Console.WriteLine("collection = {0}", GetTypeVar);

            //var ClusterIdVar = client.Cluster.ClusterId.ToString();
            //Console.WriteLine("collection = {0}", ClusterIdVar);

            //var ListDatabasesVar = client.GetDatabase(databaseName);
            //Console.WriteLine("collection = {0}", ListDatabasesVar);


            //////////////////////////////////////////// Wadders
            ///

                        //NOTES:
            //Cluster name = myFirstDatabase
            //Database name(s) = sample_airbnb | sample_analytics | sample_geospatial | sample_mflix | sample_restaurants | sample_supplies | sample_training | sample_weatherdata
            //Collections (aka tables) = listed under each database ^

            //MongoDB connection
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Mahone_1985:7f2AHeK06ScpAePs@sampledb.egd8v.mongodb.net/sampledb?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("sample_training");

            //List collection names
            Console.WriteLine("Collection Names = ");
            var dbTableList = database.ListCollectionNames().ToList();
            foreach (var db in dbTableList)
            {
                Console.WriteLine(db);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            //BsonDoc for dbstats
            var command = new BsonDocument { { "dbstats", 1 } };
            var res = database.RunCommand<BsonDocument>(command);
            Console.WriteLine("dbstats = {0}", res.ToJson());
            Console.WriteLine("");
            Console.WriteLine("");

            //BsonDoc with filter for companies called Facebook

            var companies = database.GetCollection<BsonDocument>("companies");
            var filter = Builders<BsonDocument>.Filter.Eq("name", "Facebook");
            var doc = companies.Find(filter).FirstOrDefault();
            Console.WriteLine(doc.ToString());




        }
    }
}
