using System;
using System.Collections.Generic;

namespace PizzaStore.DataAccess
{
    public partial class PizzaIngredients
    {
        public PizzaIngredients()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public int IngredientId { get; set; }

        public virtual Ingredients Ingredient { get; set; }
        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
