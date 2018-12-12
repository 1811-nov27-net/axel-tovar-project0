using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace PizzaStore.Library
{
    public class Orders
    {
        private int? _totalPizzas;

        public int id { get; set; }

        public DateTime orderTime{get;set;}

        public int? NumberOfPizzas
        {
            get => _totalPizzas;
            set
            {
                if (value > 12)
                {
                    throw new ArgumentException("You can only order a maxium of 12 pizzas");
                }
                _totalPizzas = value;
            }
        }

        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();



    }
}
