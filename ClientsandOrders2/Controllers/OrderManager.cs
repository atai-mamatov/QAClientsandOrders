using ClientsandOrders.Data.Models.Entities;
using ClientsandOrders2.CMD;

namespace ClientsandOrders.BL.Controllers
{
    public class OrderManager
    {
        private List<Order> clients = new List<Order>();
        public Order MakeOrder(string description, float orderPrice, DateTime orderDate, uint clientId)
        {
            Console.Clear();
            Console.WriteLine("Lets create an order!\n");
            List<Client> clients = Menu.clientController.GetAll();
            if(clients.Count == 0)
            {
                Console.WriteLine("There are no clients yet. Please create a client\n" +
                    "Press any key to continue");
                Console.ReadKey();
                Menu.Start();
            }
            Console.WriteLine("Choose which client you want add order to please");
            for(int i = 0; i < clients.Count; i++)
            {
                Console.WriteLine($"{i+1}. {clients[i]}");
            }
            Console.WriteLine("Enter number of your client please");
            int clientNumber = int.Parse(Console.ReadLine());
            Client client = clients[clientNumber - 1];
            string description = ConsoleHelper.GetString("description");
            float orderPrice = ConsoleHelper.GetInt("order price");
            DateTime dateAdd = DateTime.Now;
            Order order = new Order()
            {
                Description = description,
                OrderPrice = orderPrice,
                OrderDate = dateAdd,
            };
            return order;
        }

        public void Edit(uint orderId, string description, float orderPrice, DateTime orderDate, DateTime closeDateTime)
        {

        }


        public void Delete(uint orderId)
        {

        }









    }
}
