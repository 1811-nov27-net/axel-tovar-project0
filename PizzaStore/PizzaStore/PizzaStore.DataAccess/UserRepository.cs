using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStore.DataAccess
{
    public class UserRepository : IUserRepository
    {
        public PizzaStoreDBContext Db;

        public UserRepository(PizzaStoreDBContext db)
        {
            Db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Users> GetAllUsers()
        {
            // returns all Users within the database
            // AsNoTracking will allow that and also remove the performance overhead of it 

            return Db.Users.AsNoTracking().ToList();
        }

        public IEnumerable<Users> GetAllUsersDefaultLocation()
        {
            
            return Db.Users.Include(u => u.UserLocation).AsNoTracking();
          
        }

        public UserLocation GetLocationByUserID(int id)
        {

            return Db.UserLocation.Find(id);
        }

        public Users GetUserById(int id)
        {
            return Db.Users.Find(id);
        }

    }
}
