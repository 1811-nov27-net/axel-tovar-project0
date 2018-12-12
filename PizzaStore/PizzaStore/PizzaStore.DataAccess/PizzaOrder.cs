using System;
using System.Collections.Generic;

namespace PizzaStore.DataAccess
{
    public partial class PizzaOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
