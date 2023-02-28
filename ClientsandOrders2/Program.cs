using ClientsandOrders.BL.Controllers;
using ClientsandOrders.Data.Models.Entities;

while (true)
{

    Console.WriteLine("Choose an action:");
    Console.WriteLine("1. Add client");
    Console.WriteLine("2. Edit client");
    Console.WriteLine("3. Remove client");
    Console.WriteLine("4. Add order");
    Console.WriteLine("5. Edit order");
    Console.WriteLine("6. Remove order");
    Console.WriteLine("0. Exit");

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter second name:");
            string secondName = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            string phoneNum = Console.ReadLine();
            Console.WriteLine("Enter order amount:");
            uint orderAmount = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Enter date added (yyyy-MM-dd):");
            DateTime dateAdd = DateTime.Parse(Console.ReadLine());
            ClientManager.AddClient(firstName, secondName, phoneNum, orderAmount, dateAdd);
            Console.WriteLine("Client added successfully.");
            break;

        case 2:
            Console.WriteLine("Enter client index to edit:");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter first name:");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter second name:");
            secondName = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            phoneNum = Console.ReadLine();
            Console.WriteLine("Enter order amount:");
            orderAmount = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Enter date added (yyyy-MM-dd):");
            dateAdd = DateTime.Parse(Console.ReadLine());
            ClientManager.EditClient(index, firstName, secondName, phoneNum, orderAmount);
            Console.WriteLine("Client edited successfully.");
            break;




    }
}
