using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using DBLayer.Interface;
using DBLayer.Class;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Runtime;
using Newtonsoft.Json;

namespace DBLayer
{
    public class MDBC : IMDBD
    {
        private string _connectionstring = "mongodb://admin:admin@ds035703.mongolab.com:35703/cookbook";
        private  MongoClient _client;
        private  IMongoDatabase _db;
        private  MDBC _instance;

        public MDBC()
        {
            _client = new MongoClient(_connectionstring);
            _db = _client.GetDatabase("cookbook");
        }

        public  MDBC Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MDBC();
                }
                return _instance;
            }
        }

        public MongoClient getClient()
        {
            return _instance._client;
        }

        /// <summary>
        /// Insert item in collection
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="item">object, that we want to insert</param>
        public void insertUnit<T>(T item)
        {
            try
            {
                _db.GetCollection<T>(typeof(T).Name.ToLower()).InsertOneAsync(item).Wait();
            }
            catch (Exception ex)
            {             
                Console.WriteLine("Error: " + ex);
            }
        }

        /// <summary>
        /// Get the complete collection of documents
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> getFullCollection<T>()
        {
            var filter = new BsonDocument();
            return _db.GetCollection<T>(typeof(T).Name.ToLower()).Find(filter).ToListAsync().Result;
        }

        /// <summary>
        /// Find an elem by ID in collection. Return type String.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">ID of item in collection</param>
        /// <returns></returns>
        public T findByID<T>(ObjectId id) where T : MongoObject
        {
            var col = _db.GetCollection<T>(typeof(T).Name.ToLower());
            var query = Query<T>.EQ(x => x.id, id);
            //паровоз-паровоз, все мы любим паровоз
            return _db.GetCollection<T>(typeof(T).Name.ToLower()).Find(query.ToString()).FirstAsync().Result;
        }

        #region Test feature
        /// <summary>
        /// Test method for create collection
        /// </summary>
        /// <param name="name">Name of collection, that you want to create</param>
        public void TestCreateCollection(string name)
        {
           _db.CreateCollectionAsync(name).Wait();
        }



        #endregion

    }
}
