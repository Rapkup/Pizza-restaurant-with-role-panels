namespace WEBKITTER.UI.Models
{
    public class OrderModel
    {
        public OrderModel()
        {

        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }

        public int CustomerId { get; set; }
        public int DishId { get; set; }

    }
}
