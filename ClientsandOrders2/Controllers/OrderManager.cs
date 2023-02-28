using ClientsandOrders.Data.Models.Entities;

namespace ClientsandOrders.BL.Controllers
{
    public class OrderManager
    {
        private List<Order> clients = new List<Order>();
        public void Add(string description, float orderPrice, DateTime orderDate, uint clientId)
        {
            Order order = new Order
            {
                Description = description,
                OrderPrice = orderPrice,
                OrderDate = orderDate,
                ClientId = clientId,
            };
        }

        public void Edit(uint orderId, string description, float orderPrice, DateTime orderDate, DateTime closeDateTime)
        {
            Order order = clients.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                throw new ArgumentException($"Order with id={orderId} not found.");
            }

            order.Description = description;
            order.OrderPrice = orderPrice;
            order.OrderDate = orderDate;
            order.CloseDate = closeDateTime;

           
        }


        public void Delete(uint orderId)
        {
            Order order = clients.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                clients.Remove(order);
            }
            else
            {
                throw new ArgumentException($"Order with id={orderId} not found.");
            }
        }









    }
}
