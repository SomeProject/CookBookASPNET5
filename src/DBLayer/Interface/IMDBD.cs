using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using DBLayer.Class;


namespace DBLayer.Interface
{
    interface IMDBD
    {

        /// <summary>
        /// Insert item in collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        void insertUnit<T>(T item);

        /// <summary>
        /// Get the complete collection of documents
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> getFullCollection<T>();

        /// <summary>
        /// Find an elem by ID in collection. Return type String.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T findByID<T>(ObjectId id) where T : MongoObject;

    }
}
