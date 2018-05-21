using MongoDB.Driver;
using QA.Core.Model.Users;
using QA.Core.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminSite.Database.MongoDb
{
    public class UserMongoDbRepository : GenericDbRepository<User>
    {
        private MongoDbContext _db;
        public UserMongoDbRepository (MongoDbContext db)
        {
            _db = db;
        }

        public override User Add(User item)
        {
            _db.Users.InsertOne(item);
            return item;
        }

        public override User Delete(User item)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public override User Update(User item)
        {
            throw new NotImplementedException();
        }
    }

    public class GenericMongoDbRepository<T> : GenericDbRepository<T>
    {
        private MongoDbContext _db;
        public GenericMongoDbRepository(MongoDbContext db)
        {
            _db = db;
            _collection = _db.GetCollection<T>();
        }
        private IMongoCollection<T> _collection;

        public override T Add(T item)
        {
            _collection.InsertOne(item);
            return item;
        }

        public override T Delete(T item)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public override T Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}