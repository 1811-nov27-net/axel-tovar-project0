using System;
using System.Collections.Generic;

namespace PizzaStore.DataAccess
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CrustType { get; set; }
        public decimal LinePrice { get; set; }
        public int? PizzaIngredientId { get; set; }

        public virtual Ingredients PizzaIngredient { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrder { get; set; }
    }
}
