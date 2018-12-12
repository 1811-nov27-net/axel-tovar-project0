using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStore.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly PizzaStoreDBContext Db;

        public UserRepository(PizzaStoreDBContext db)
        {
            Db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public IList<Users> GetAllUsers()
        {
            // returns all Users within the database
            // AsNoTracking will allow that and also remove the performance overhead of it 

            return Db.Users.AsNoTracking().ToList();
        }

        public IEnumerable<Users> GetAllUsersDefaultLocation()
        {
            //Genre trackedGenre = Db.Genre.First(g => g.Name == withGenre);
           // List<UserLocation> AllLocations = new List<UserLocation>();
            // List<Users> AllUsers = new List<Users>();

            // AllUsers = Db.Users.AsNoTracking().ToList();
            // AllLocations = Db.UserLocation.AsNoTracking().ToList();

           //var innerjoinquery = (from user in allusers
           //join ul in alllocations on user.id equals ul.userid
           //select user);

            return Db.Users.Include(u => u.UserLocation).AsNoTracking();
          
        }

        public Users GetSingleUserDefaultLocation(int id)
        {
            throw new NotImplementedException();
        }

        public Users GetUserById(int id)
        {
            return Db.Users.Find(id);
        }

        public Users GetUserByName(string FirstName, string LastName)
        {
            string _first = FirstName;
            string _last = LastName;

            return Db.Users.Find(_first, _last);
        }
    }
}
