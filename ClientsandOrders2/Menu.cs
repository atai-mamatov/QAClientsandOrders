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
            Console.WriteLine("Main Menu\n\n" +
                "Clients - C \n" +
                "Orders - O");

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



            //Console.WriteLine("Choose an action:");
            //Console.WriteLine("1. Add client");
            //Console.WriteLine("2. Edit client");
            //Console.WriteLine("3. Remove client");
            //Console.WriteLine("4. Add order");
            //Console.WriteLine("5. Edit order");
            //Console.WriteLine("6. Remove order");
            //Console.WriteLine("0. Exit");

            //int choice = Convert.ToInt32(Console.ReadLine());

            //switch (choice)
            //{
            //    //case 1:
            //    //    ClientManager.MakeClient();
            //    //    Console.WriteLine("Client added successfully.");
            //    //    break;
            //    //case 2:
            //    //    Console.WriteLine("Enter client index to edit:");
            //    //    int index = Convert.ToInt32(Console.ReadLine());
            //    //    Console.WriteLine("Enter first name:");
            //    //    firstName = Console.ReadLine();
            //    //    Console.WriteLine("Enter second name:");
            //    //    secondName = Console.ReadLine();
            //    //    Console.WriteLine("Enter phone number:");
            //    //    phoneNum = Console.ReadLine();
            //    //    Console.WriteLine("Enter order amount:");
            //    //    OrderAmount = Convert.ToUInt32(Console.ReadLine());
            //    //    Console.WriteLine("Enter date added (yyyy-MM-dd):");
            //    //    dateAdd = DateTime.Parse(Console.ReadLine());
            //    //    ClientManager.EditClient(index, firstName, secondName, phoneNum);
            //    //    Console.WriteLine("Client edited successfully.");
            //    //    break;




            //}
        }

        public static void Next<T>() where T : BaseEntity
        {


        }


    }
}