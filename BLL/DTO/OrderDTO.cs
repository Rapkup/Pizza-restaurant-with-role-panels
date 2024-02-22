

using BLL.Interfaces;

namespace BLL.DTO
{
    public class OrderDTO : IDTO
    {


        public OrderDTO()
        {
        }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public int CustomerId { get; set; }

        public int DishID { get; set; }
    }
}
