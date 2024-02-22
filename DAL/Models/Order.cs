using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order : Temple
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int CustomerId { get; set; }

        public int DishID { get; set; }

        public Order(int id, DateTime orderDate, string status, int custId, int dishId)
        {
            OrderID = id;
            OrderDate = orderDate;
            OrderStatus = status;
            CustomerId = custId;
            DishID = dishId;
        }
        public Order(DateTime orderDate, string status, int custId, int dishId)
        {

            OrderDate = orderDate;
            OrderStatus = status;
            CustomerId = custId;
            DishID = dishId;
        }

        public Order()
        {

        }
    }
}
