using System;
using System.Collections.Generic;

namespace PizzaStore.DataAccess
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            PizzaIngredients = new HashSet<PizzaIngredients>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StockNumber { get; set; }
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<PizzaIngredients> PizzaIngredients { get; set; }
    }
}
