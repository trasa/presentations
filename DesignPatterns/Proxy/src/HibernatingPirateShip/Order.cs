using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace HibernatingPirateShip
{
    [ActiveRecord("Orders", Lazy=true)]
    public class Order
    {
        [PrimaryKey(Generator = PrimaryKeyType.Identity, Column = "OrderID", ColumnType = "Int32")]
        public virtual int Id { get; set; }

        [Property("OrderName")]
        public virtual string Name { get; set; }

        // default is Eager Loading
        [HasMany(typeof(OrderDetail), Lazy=true)]
        public virtual IList<OrderDetail> OrderDetails { get; set;  }
    }
}
