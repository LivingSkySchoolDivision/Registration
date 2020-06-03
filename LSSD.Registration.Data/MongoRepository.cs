using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver.Linq;
using System.Linq;
using LSSD.Registration.Model;

namespace LSSD.Registration.Data
{
    public class MongoRepository<T> : IRepository<T> where T : IGUIDable
    {
        MongoDbConnection _db;
        IMongoCollection<T> _collection;

        public MongoRepository(MongoDbConnection db)
        {
            this._db = db;
            this._collection = _db.DB.GetCollection<T>(typeof(T).Name);
        }

        public void Delete(T entity)
        {
            _collection.DeleteOne(_ => _.Id == entity.Id);
        }

        public IList<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _collection.AsQueryable<T>().Where(predicate.Compile()).ToList();
        }

        public IList<T> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public T GetById(string id)
        {
            try
            {
                return GetById(Guid.Parse(id));
            } 
            catch (FormatException)
            {
                return default(T);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public T GetById(Guid id)
        {
            return (T)_collection.Find<T>(_ => _.Id == id).FirstOrDefault();
        }

        public Guid Insert(T entity)
        {
            Guid newID = Guid.NewGuid();
            entity.Id = newID;
            _collection.InsertOne(entity);
            return newID;
        }

        public void Update(T entity)
        {
            if (entity.Id == null)
            {
                Insert(entity);
            } else
            {
                _collection.ReplaceOne(_ => _.Id == entity.Id, entity);
            }
        }
    }
}
