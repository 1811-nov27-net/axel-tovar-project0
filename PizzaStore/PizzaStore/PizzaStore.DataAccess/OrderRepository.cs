using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStore.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        public PizzaStoreDBContext Db;

        public OrderRepository(PizzaStoreDBContext db)
        {
            Db = db;
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Store> GetAllStores()
        {
            // returns all Users within the database
            // AsNoTracking will allow that and also remove the performance overhead of it 

            return Db.Store.AsNoTracking().ToList();
        }
        public Store GetStoreById(int id)
        {
            return Db.Store.Find(id);

        }
        public IEnumerable<Orders> GetOrdersWithStoreID(Store store)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orders> GetOrdersWithUserLocationID(UserLocation userLocation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Store> GetAllStoreIngredientsByStoreID()
        {
            return Db.Store.Include(i => i.Ingredients).AsNoTracking();
        }

        public IEnumerable<Pizza> GetPizzaOptions()
        {
            return Db.Pizza.AsNoTracking().ToList();
        }

        public void CreatePizzaOrder(PizzaOrder pizzaOrder)
        {
            Db.Add(pizzaOrder);
        }
        public void Save()
        {
            Db.SaveChanges();
        }

        public void CreatePizzaOrder(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PizzaOrder> GetPizzaOrders()
        {
            throw new NotImplementedException();
        }

        public void DecreaseStoresStock(int id)
        {
            Db.Ingredients.Find(id).StockNumber -- ;
        }
    }
}
