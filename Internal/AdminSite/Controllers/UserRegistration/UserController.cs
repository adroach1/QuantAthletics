using AdminSite.Database.Sql;
using MongoDB.Driver;
using QA.Core.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace AdminSite.Controllers
{
    public class UserController: ApiController
    {
        private QaDbContext _db;
        public UserController(QaDbContext db)
        {
            _db = db;
        }

        public async Task<User> CreateUser(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        [HttpGet]
        public IEnumerable<User> SearchUsers([FromUri] UserSearch userSearch)
        {
            var users = _db.Users.AsQueryable<User>();
            if (userSearch.Id != null)
                users = users.Where(u => u.Id == userSearch.Id);
            if (userSearch.EmailAddress != null)
                users = users.Where(u => u.EmailAddress.Equals(userSearch.EmailAddress));
            if (userSearch.Username != null)
                users = users.Where(u => u.Username.Equals(userSearch.Username));
            var foundUsers = users.ToList();
            return foundUsers;
        }
    }
}
