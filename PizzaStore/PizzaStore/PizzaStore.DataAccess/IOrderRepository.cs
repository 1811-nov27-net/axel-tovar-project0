using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.DataAccess
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> GetOrdersWithUserLocationID(UserLocation userLocation);

        IEnumerable<Orders> GetOrdersWithStoreID(Store store);

        IEnumerable<PizzaOrder> GetPizzaOrders();

        IEnumerable<Orders> GetAllOrders();

        IEnumerable<Store> GetAllStores();

        Store GetStoreById(int id);

        void CreatePizzaOrder(Pizza pizza);

        IEnumerable<Store> GetAllStoreIngredientsByStoreID();

        IEnumerable<Pizza> GetPizzaOptions();

        void DecreaseStoresStock(int id);

        void Save();
    }
}
