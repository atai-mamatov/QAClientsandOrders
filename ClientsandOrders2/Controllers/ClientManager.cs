using ClientsandOrders.Data.Database.SqlServer;
using ClientsandOrders.Data.Models.Entities;
using ClientsandOrders.BL.Controllers;
using ClientsandOrders2.CMD;
using System.Collections.Generic;

namespace ClientsandOrders.BL.Controllers
{
    public static class ClientManager
    {
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
            Console.Clear();
            Console.WriteLine("Lets add a new client");
            Client client = MakeClient();
            Menu.clientController.Add(client);
            Console.Clear();
            Console.WriteLine("A new client has been created\n" +
                "Press any key to continue");
            Console.ReadKey();
            Menu.Start();
        }

        public static void AddOrderToClient(int clientId, Order order)
        {
            //Client client = clients.FirstOrDefault(c => c.Id == clientId);
            //if (client != null)
            //{
            //    client.OrdersList.Add(order);
            //}
        }

        public static void DeleteClient()
        {
            Console.Clear();
            List<Client> client = Client.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                Menu.clientController.Delete(client);
                Console.Clear();
                Console.WriteLine("Client has been deleted successfully!");
            }

        }

        public static Client EditClient(int clientId, string firstName, string secondName, string phoneNum)
        {
            //Client client = clients.FirstOrDefault(c => c.Id == clientId);
            //if (client != null)
            //{

            //    client.FirstName = firstName;
            //    client.SecondName = secondName;
            //    client.PhoneNum = phoneNum;
            //    client.OrderAmount = orderAmount;
            //}
            //return client;
            return null;
        }
    }

}
