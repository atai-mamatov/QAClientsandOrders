using ClientsandOrders.Data.Models.Entities;

namespace ClientsandOrders.BL.Controllers
{
    public class ClientManager
    {
        private List<Client> clients = new List<Client>();

        public void Add(string firstName, string secondName, string phoneNum, uint orderAmount, DateTime dateAdd)
        {
            Client client = new Client
            {
                FirstName = firstName,
                SecondName = secondName,
                PhoneNum = phoneNum,
                OrderAmount = orderAmount,
                DateAdd = dateAdd
            };
            clients.Add(client);
        }

        public void AddOrderToClient(int clientId, Order order)
        {
            Client client = clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                client.OrdersList.Add(order);
            }
        }

        public void Delete(int clientId)
        {
            Client client = clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                clients.Remove(client);
            }
        }

        public void Edit(int clientId, string firstName, string secondName, string phoneNum, uint orderAmount)
        {
            Client client = clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                client.FirstName = firstName;
                client.SecondName = secondName;
                client.PhoneNum = phoneNum;
                client.OrderAmount = orderAmount;
            }
        }
    }

}
