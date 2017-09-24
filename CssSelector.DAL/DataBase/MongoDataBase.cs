using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CssSelector.Common.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CssSelector.DAL.DataBase
{
    public class MongoDataBase<T>:IDataBase<T> where T : class
    {
        private IMongoDatabase _database;
        private string _tableName;

        public  MongoDataBase(string connectionString)
        {
            var client = new MongoClient(connectionString);
            this._database = client.GetDatabase(MongoUrl.Create(connectionString).DatabaseName);
            _tableName = typeof(T).Name;
        }

        public IEnumerable<T> GetListByParam(string parameterName, string value)
        {
            
            var collection = this._database.GetCollection<BsonDocument>(_tableName);
            var filte=new BsonDocument(parameterName, value);
            var result = collection.Find(filte).ToList().Select(item=> BsonSerializer.Deserialize<T>(item));
            return result;
        }

        public IEnumerable<T> GetList()
        {
            var collection = this._database.GetCollection<BsonDocument>(_tableName);
            var filte = new BsonDocument();
            var result = collection.Find(filte).ToList().Select(item => BsonSerializer.Deserialize<T>(item));
            return result;
        }

        public void Update(T element)
        {
            throw new NotImplementedException();
        }

        public void Insert(T element)
        {
            var collection = this._database.GetCollection<BsonDocument>(_tableName);
            var bsonDocument = element.ToBsonDocument();
            collection.InsertOne(bsonDocument);
        }
    }
}
