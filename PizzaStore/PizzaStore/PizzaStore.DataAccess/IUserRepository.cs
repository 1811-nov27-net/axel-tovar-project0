using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.DataAccess
{
    public interface IUserRepository
    {

        IEnumerable<Users> GetAllUsers();

        IEnumerable<Users> GetAllUsersDefaultLocation();

        Users GetUserById(int id);

        UserLocation GetLocationByUserID(int id);


    }
}
