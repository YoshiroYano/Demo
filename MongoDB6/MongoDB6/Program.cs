﻿using System;
using System.Diagnostics;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB6
{
    class Program
    {

        private const string UserName = "admin";

        private const string Password = "password";

        private const string DatabaseName = "SmallObjectData";

        private const string CollectionName = "SmallObjectData";

        private const string DatabaseLargeName = "LargeObjectData";

        private const string CollectionLargeName = "LargeObjectData";

        private const string CollectionMiddleName = "MiddleObjectData";

        private const string DatabaseMiddleName = "MiddleObjectData";

        private const int MiddleDataSize = 80000;

        private const int LargeDataSize = 100000;

        private const int Count = 1000000;

        private const int MiddleCount = 1000000;

        private const int LargeCount = 1000000;

        private const int Divider = 100000;

        static void Main()
        {
            var mongoClient = new MongoClient(string.Format("mongodb://{0}:{1}@localhost", UserName, Password));

            //WriteSmallData(mongoClient);
            //WriteMiddleData(mongoClient);
            //WriteLargeData(mongoClient);

            //SelectSmallData(mongoClient, Divider);
            //SelectLargeData(mongoClient, Divider);

            Console.WriteLine("Please enter any key...");
            Console.ReadKey();
        }

        private static void SelectSmallData(MongoClient mongoClient, int divider)
        {
            Console.WriteLine("SelectSmallData");

            var database = mongoClient.GetDatabase(DatabaseName);

            var sw = new Stopwatch();
            
            sw.Start();
            var collection = database.GetCollection<SmallObjectData>(CollectionName);
            var list = collection.Find(data => data.No % divider == 0).ToList();
            sw.Stop();

            Console.WriteLine("\tTime : {0} ms , Count : {1}", sw.ElapsedMilliseconds, list.Count);
        }

        private static void SelectMiddleData(MongoClient mongoClient, int divider)
        {
            Console.WriteLine("SelectMiddleData");

            var database = mongoClient.GetDatabase(DatabaseMiddleName);

            var sw = new Stopwatch();

            sw.Start();
            var collection = database.GetCollection<MiddleObjectData>(CollectionLargeName);
            var list = collection.Find(data => data.No % divider == 0).ToList();
            sw.Stop();

            Console.WriteLine("\tTime : {0} ms , Count : {1}", sw.ElapsedMilliseconds, list.Count);
        }

        private static void SelectLargeData(MongoClient mongoClient, int divider)
        {
            Console.WriteLine("SelectLargeData");

            var database = mongoClient.GetDatabase(DatabaseLargeName);

            var sw = new Stopwatch();

            sw.Start();
            var collection = database.GetCollection<LargeObjectData>(CollectionLargeName);
            var list = collection.Find(data => data.No % divider == 0).ToList();
            sw.Stop();

            Console.WriteLine("\tTime : {0} ms , Count : {1}", sw.ElapsedMilliseconds, list.Count);
        }

        private static void WriteSmallData(MongoClient mongoClient)
        {
            DropDatabase(mongoClient, DatabaseName);
            InsertSmallData(mongoClient);
        }

        private static void WriteMiddleData(MongoClient mongoClient)
        {
            DropDatabase(mongoClient, DatabaseMiddleName);
            InsertMiddleData(mongoClient);
        }

        private static void WriteLargeData(MongoClient mongoClient)
        {
            DropDatabase(mongoClient, DatabaseLargeName);
            InsertLargeData(mongoClient);
        }

        private static void DropDatabase(MongoClient mongoClient, string database)
        {
            Console.WriteLine("DropDatabase");

            var sw = new Stopwatch();

            sw.Start();
            mongoClient.DropDatabase(database);
            sw.Stop();

            Console.WriteLine("\tTime : {0} ms", sw.ElapsedMilliseconds);
        }

        private static void InsertSmallData(MongoClient mongoClient)
        {
            Console.WriteLine("InsertSmallData");

            var database = mongoClient.GetDatabase(DatabaseName);

            var sw = new Stopwatch();

            sw.Start();
            var collection = database.GetCollection<SmallObjectData>(CollectionName);
            for (var i = 0; i < Count; i++)
            {
                var data = new SmallObjectData
                {
                    Id = ObjectId.GenerateNewId(),
                    No = i,
                    Established = DateTime.UtcNow
                };
                collection.InsertOne(data);
            }
            sw.Stop();

            Console.WriteLine("\tTime : {0} ms", sw.ElapsedMilliseconds);
        }

        private static void InsertMiddleData(MongoClient mongoClient)
        {
            Console.WriteLine("InsertMiddleData");

            var database = mongoClient.GetDatabase(DatabaseMiddleName);

            var sw = new Stopwatch();

            sw.Start();
            var collection = database.GetCollection<MiddleObjectData>(CollectionLargeName);
            for (var i = 0; i < MiddleCount; i++)
            {
                var data = new MiddleObjectData
                {
                    Id = ObjectId.GenerateNewId(),
                    No = i,
                    DataBytes = new byte[MiddleDataSize],
                    Established = DateTime.UtcNow
                };
                collection.InsertOne(data);
            }
            sw.Stop();

            Console.WriteLine("\tTime : {0} ms", sw.ElapsedMilliseconds);
        }

        private static void InsertLargeData(MongoClient mongoClient)
        {
            Console.WriteLine("InsertLargeData");

            var database = mongoClient.GetDatabase(DatabaseLargeName);

            var sw = new Stopwatch();

            sw.Start();
            var collection = database.GetCollection<LargeObjectData>(CollectionLargeName);
            for (var i = 0; i < LargeCount; i++)
            {
                var data = new LargeObjectData
                {
                    Id = ObjectId.GenerateNewId(),
                    No = i,
                    DataBytes = new byte[LargeDataSize],
                    Established = DateTime.UtcNow
                };
                collection.InsertOne(data);
            }
            sw.Stop();

            Console.WriteLine("\tTime : {0} ms", sw.ElapsedMilliseconds);
        }

        public sealed class SmallObjectData
        {

            public ObjectId Id
            {
                get;
                set;
            }

            public int No
            {
                set;
                get;
            }

            public DateTime Established
            {
                get;
                set;
            }

        }

        public sealed class MiddleObjectData
        {

            public ObjectId Id
            {
                get;
                set;
            }

            public int No
            {
                set;
                get;
            }

            public byte[] DataBytes
            {
                set;
                get;
            }

            public DateTime Established
            {
                get;
                set;
            }

        }

        public sealed class LargeObjectData
        {

            public ObjectId Id
            {
                get;
                set;
            }

            public int No
            {
                set;
                get;
            }

            public byte[] DataBytes
            {
                set;
                get;
            }

            public DateTime Established
            {
                get;
                set;
            }

        }

    }
}
