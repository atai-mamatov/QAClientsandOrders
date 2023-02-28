using ClientsandOrders.BL.Controllers;
using ClientsandOrders.Data.Database.SqlServer;
using ClientsandOrders.Data.Models.Common;
using ClientsandOrders.Data.Models.Entities;
using ClientsandOrders.Data.Repositories.Implementations;

namespace ClientsandOrders2.CMD
{
    public static class Menu
    {
        public static AppDbContext context = new AppDbContext();


        public static Repository<Client> clientController = new Repository<Client>(context);
        public static Repository<Order> ordersController = new Repository<Order>(context);

        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Main Menu\n\n" +
                "Press C for Clients - [C] \n" +
                "Press O for Orders - [O] ");

            var choice = Console.ReadKey(true);

            while(choice.Key != ConsoleKey.C && choice.Key != ConsoleKey.O)
            {
                choice = Console.ReadKey(true);
            }

            switch (choice.Key)
            {
                case ConsoleKey.C:
                    Next<Client>();
                    break;
                case ConsoleKey.O:
                    Next<Order>();
                    break;

            }



        }

        public static void Next<T>() where T : BaseEntity
        {
            Console.Clear();
            string table = "Clients List\n\n";

            if(typeof(T) == typeof(Client))
            {
                table += "Id | First Name | Second Name | Order Amount | Add Date | Phone Number\n\n";
                List<Client> allClients = clientController.GetAll();
                foreach(Client client in allClients)
                {
                    table += client.ToString() + "\n";
                }
                Console.WriteLine(table);
                Console.ReadKey();
                Console.WriteLine("Choose what you would like to do\n" +
                    "Add Client Press A - [A]\n" +
                    "Edit Client Press E - [E]\n" +
                    "Delete Client Press D - [D]");

                var choice = Console.ReadKey(true);

                while (choice.Key != ConsoleKey.A && choice.Key != ConsoleKey.E && choice.Key != ConsoleKey.D)
                {
                    choice = Console.ReadKey(true);
                }

                switch (choice.Key)
                {
                    case ConsoleKey.A:
                        ClientManager.AddClient();
                        break;
                    case ConsoleKey.E:
                        ClientManager.EditClient();
                        break;

                }

            }
            else if (typeof(T) == typeof(Order))
            {

            }
                

        }


    }
}