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
    public class MongoRepository<T> : IRegistrationRepository<T> where T : IGUIDable
    {
        MongoDbConnection _db;
        IMongoCollection<T> _collection;

        public MongoRepository(MongoDbConnection db)
        {
            this._db = db;
            this._collection = _db.DB.GetCollection<T>(typeof(T).Name);
        }

        public void DeleteAll()
        {
            _collection.DeleteMany(_ => true);
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
                if (isValidGUID(id))
                {
                    return GetById(Guid.Parse(id));
                } else
                {
                    return default(T);
                }
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

        public IList<Guid> Insert(IList<T> entities)
        {
            // Make GUIDs for all objects
            List<Guid> newEntityGuids = new List<Guid>();
            foreach(T obj in entities)
            {
                obj.Id = Guid.NewGuid();
                newEntityGuids.Add(obj.Id);
            }
            _collection.InsertMany(entities);
            return newEntityGuids;
        }

        public Guid Insert(T entity)
        {
            entity.Id = Guid.NewGuid();
            _collection.InsertOne(entity);
            return entity.Id;
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


        private bool isValidGUID(string input)
        {
            return Guid.TryParse(input, out Guid x);
        }
    }
}
