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

            var db = new PizzaStoreDBContext(options);
            IUserRepository userRepo = new UserRepository(db);

            IOrderRepository orderRepo = new OrderRepository(db);


            // RetriveAllUser();
            Console.WriteLine("Welcome to the Pizzeria");
            Console.WriteLine();
            Console.WriteLine("Would you like to place an order?");
            Console.WriteLine();
            Console.WriteLine("Type in a 'Y' for yes, or 'N' for no");
            var input = Console.ReadLine();

            if (input == "Y" || input == "y")
            {

                //var idInput = Console.ReadLine();
                Console.WriteLine("Please select your user by ID");
                Console.WriteLine();
                foreach (var items in userRepo.GetAllUsers())
                {
                    Console.WriteLine($"Users ID: {items.Id} Full Name: {items.FirstName} {items.LastName}");

                }
              

                int UserIdInput = Convert.ToInt32(Console.ReadLine());

                var firstname = userRepo.GetUserById(UserIdInput).FirstName;
                var lastName = userRepo.GetUserById(UserIdInput).LastName;
                var userAddress = userRepo.GetLocationByUserID(UserIdInput).Address;

                // var storeLocations  = 

                //Users users = userRepo.GetUserById(idInput);
                //List<Users> users1 = new List<Users>();
                //users1.Add(userRepo.GetUserById(idInput));

                //foreach(var items in users1)
                //{
                //    Console.WriteLine($"{items.FirstName}");
                //}

                Console.WriteLine($"Hello {firstname} {lastName}");

                Console.WriteLine();

                Console.WriteLine("Store ID" + "       " + "Store Address");

                foreach (var items in orderRepo.GetAllStores())
                {
                    Console.WriteLine($"{items.Id}               {items.Address}, {items.State}");

                }
                Console.WriteLine();
                Console.WriteLine("Please select the store you would like to order from by 'ID'");
                Console.WriteLine();
                int idStoreInput = Convert.ToInt32(Console.ReadLine());

                var store = orderRepo.GetStoreById(idStoreInput);

                Console.WriteLine($"You chose store # {store.Id} Address: {store.Address} {store.State}");

                Console.WriteLine($"Your default delivery location is {userAddress}");

                Console.WriteLine();

                var availableIngredients = orderRepo.GetAllStoreIngredientsByStoreID().Where(i => i.Id == idStoreInput);

                var availablePizzas = orderRepo.GetPizzaOptions();

                Console.WriteLine("Select your Pizza options by 'ID'");

                foreach (var items in availablePizzas)
                {
                    Console.WriteLine($"{items.Id}  pizza:  {items.Name} price: {items.LinePrice} ");
                }
                int pizzaID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                Console.WriteLine("Select your pizza topping option by 'ID'");

                foreach (var items in availableIngredients)
                {

                    foreach (var ing in items.Ingredients)
                    {
                        Console.WriteLine($" id: {ing.Id} topping:  {ing.Name} " +
                            $"curren stock for this store: {ing.StockNumber}");

                    }
                }
                int ingredientID = Convert.ToInt32(Console.ReadLine());

              //  orderRepo.DecreaseStoresStock(ingredientID);

                foreach (var items in availableIngredients)
                {

                    foreach (var ing in items.Ingredients)
                    {
                        Console.Write($" id: {ing.Id} topping:  {ing.Name} current store stock: {ing.StockNumber}");

                    }
                }


            }
            else if (input == "N" || input == "n")
            {
                Console.WriteLine("No: here");
            }
            else
            {
                Console.WriteLine($"Invalid input \"{input}\".");
            }
              

          // RetriveAllUsersWithDefaultAddress();
        }

        static void RetriveAllUser()
        {
            using (var db = new PizzaStoreDBContext(options))
            {
                IUserRepository userRepo = new UserRepository(db);

                userRepo.GetAllUsers();

                foreach(var items in userRepo.GetAllUsers())
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
