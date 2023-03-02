using ClientsandOrders.Data.Models.Entities;
using ClientsandOrders2.CMD;

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

            Console.CursorVisible = true;

            Console.WriteLine("Lets add a new client");
            Client client = MakeClient();
            Console.CursorVisible= false;
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


        public static void DeleteClient(string table)
        {
            Console.Clear();
            Console.CursorVisible = true;

            Console.WriteLine($"Input ID of a client for deleting:\n{table}");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Incorrect input, try again: ");
            }
            Client client = Menu.clientController.GetById(choice);
            Console.WriteLine($"\nAre you sure you want to delete {client.FirstName} {client.SecondName}?\n" +
                $"[Y] - YES    [N] - NO");
            Console.CursorVisible = false;

            ConsoleKeyInfo button;
            do
            {
                button = Console.ReadKey(true);
            } while (button.Key != ConsoleKey.Y && button.Key != ConsoleKey.N);
            switch (button.Key)
            {
                case ConsoleKey.Y:
                    Menu.clientController.Delete(client);
                    Console.WriteLine($"{client.FirstName} {client.SecondName} has been deleted!");
                    break;
            }
            Console.WriteLine("Press any button to return to the main menu...");
            Console.ReadKey(true);
            Menu.Start();
        }



        public static Client EditClient(string table)
        {
            Console.Clear();
            Console.CursorVisible = true;

            Console.WriteLine($"Input ID of a client for edititng:\n{table}");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Incorrect input, try again: ");
            }
            Client client = Menu.clientController.GetById(choice);
            Console.WriteLine($"\nAre you sure you want to edit {client.FirstName} {client.SecondName}?\n" +
                $"[Y] - YES    [N] - NO");
            client.FirstName = ConsoleHelper.GetString("first name");
            client.SecondName = ConsoleHelper.GetString("second name");
            client.PhoneNum = ConsoleHelper.GetString("phone number");
            Menu.clientController.Edit(client);
            Console.Clear();
            Console.WriteLine("A client has been updated\n" +
                "Press any key to continue");
            Console.ReadKey();
            Menu.Start();
            return client;
        }

    }

}
