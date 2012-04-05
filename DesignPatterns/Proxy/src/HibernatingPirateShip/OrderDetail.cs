using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace HibernatingPirateShip
{
    [ActiveRecord("OrderDetails")]
    public class OrderDetail
    {
        [PrimaryKey(Generator = PrimaryKeyType.Identity, Column = "OrderDetailID", ColumnType = "Int32")]
        public int Id { get; set; }

        [BelongsTo("OrderID", Type=typeof(Order))]
        public Order Order { get; set; }

        [Property("ProductName")]
        public string Name { get; set;  }

        [Property]
        public decimal LinePrice { get; set; }
    }
}
