using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.DataAccess
{
    public interface IPizzaOrderRepository
    {

        void AddPizza(Pizza pizza);

        void Save();
    }
}
