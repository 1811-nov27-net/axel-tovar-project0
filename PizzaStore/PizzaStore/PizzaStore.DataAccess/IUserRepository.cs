using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.DataAccess
{
    public interface IUserRepository
    {

        IList<Users> GetAllUsers();

        IEnumerable<Users> GetAllUsersDefaultLocation();

        Users GetSingleUserDefaultLocation(int id);

        Users GetUserById(int id);

        Users GetUserByName(string FirstName, string LastName);

    }
}
