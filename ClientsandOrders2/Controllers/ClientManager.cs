using ClientsandOrders.Data.Database.SqlServer;
using ClientsandOrders.Data.Models.Entities;
using ClientsandOrders.BL.Controllers;
using ClientsandOrders2.CMD;

namespace ClientsandOrders.BL.Controllers
{
    public static class ClientManager
    {
        private static List<Client> clients = new List<Client>();

        public static Client MakeClient()
        {
            string firstName = ConsoleHelper.GetString("first name");
            string secondName = ConsoleHelper.GetString("second name");
            string phoneNum = ConsoleHelper.GetString("phone number");
            DateTime dateAdd = DateTime.Now;
            Client client = new Client()
            {
                FirstName = firstName,
                SecondName = secondName,
                PhoneNum = phoneNum,
                DateAdd = dateAdd
            };
            return client;
        }

        public static void AddClient()
        {
            Client client = MakeClient();
            clients.Add(client);
        }

        public static void AddOrderToClient(int clientId, Order order)
        {
            Client client = clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                client.OrdersList.Add(order);
            }
        }

        public static void DeleteClient(int clientId)
        {
            Client client = clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                clients.Remove(client);
            }
        }

        public static Client EditClient(int clientId, string firstName, string secondName, string phoneNum, uint orderAmount)
        {
            Client client = clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {

                client.FirstName = firstName;
                client.SecondName = secondName;
                client.PhoneNum = phoneNum;
                client.OrderAmount = orderAmount;
            }
            return client;
        }
    }

}
