using PizzaStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PizzaStore.UI
{
    class Program
    {
        static DbContextOptions<PizzaStoreDBContext> options = null;

        static void Main(string[] args)
        {
            var connectionString = SecretConfiguration.ConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<PizzaStoreDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            options = optionsBuilder.Options;

           // RetriveAllUser();
            Console.WriteLine();

            RetriveAllUsersWithDefaultAddress();
        }

        static void RetriveAllUser()
        {
            using (var db = new PizzaStoreDBContext(options))
            {
                IUserRepository movieRepo = new UserRepository(db);

                movieRepo.GetAllUsers();

                foreach(var items in movieRepo.GetAllUsers())
                {
                    Console.WriteLine($"ID: {items.Id} Full Name: {items.FirstName} {items.LastName}");
                }
            }
        }
        static void RetriveAllUsersWithDefaultAddress()
        {
            using (var db = new PizzaStoreDBContext(options))
            {
                IUserRepository userRepo = new UserRepository(db);

                userRepo.GetAllUsersDefaultLocation();

                foreach (var items in userRepo.GetAllUsersDefaultLocation())
                {
                    Console.Write($"Users ID: {items.Id} Full Name: {items.FirstName} {items.LastName}");
                    foreach(var location in items.UserLocation)
                    {

                        Console.Write($" Address: {location.Address}\n");
                    }
                }

                Console.ReadKey();
            }
        }
    }
}
