using ClientsandOrders.Data.Models.Common;
using ClientsandOrders.Data.Repositories.Interfaces;

namespace ClientsandOrders2.CMD
{
    public static class Menu<T> where T : BaseEntity
    {
        private static readonly IRepository<T> _repository;
        private static readonly List<string> _menuItems = new List<string>();






            public static Menu(IRepository<T> repository)
            {
                _repository = repository;
                AddMenuItem("Add new item");
                AddMenuItem("View all items");
                AddMenuItem("View item by ID");
                AddMenuItem("Edit item by ID");
                AddMenuItem("Delete item by ID");
                AddMenuItem("Exit");
            }

            public static void AddMenuItem(string menuItem)
            {
                _menuItems.Add(menuItem);
            }

            public static void DisplayMenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Select an option:");

                    for (int i = 0; i < _menuItems.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {_menuItems[i]}");
                    }

                    Console.Write("Enter your choice (1 - {0}): ", _menuItems.Count);

                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                AddNewItem();
                                break;
                            case 2:
                                ViewAllItems();
                                break;
                            case 3:
                                ViewItemById();
                                break;
                            case 4:
                                EditItemById();
                                break;
                            case 5:
                                DeleteItemById();
                                break;
                            case 6:
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Press any key to try again...");
                                Console.ReadKey(true);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey(true);
                    }
                }
            }

            private static void AddNewItem()
            {
                Console.Clear();
                Console.WriteLine("Enter item details:");

                // Create a new instance of T and set its properties
                var item = Activator.CreateInstance<T>();
                foreach (var property in typeof(T).GetProperties())
                {
                    Console.Write("{0}: ", property.Name);
                    var value = Console.ReadLine();
                    property.SetValue(item, Convert.ChangeType(value, property.PropertyType));
                }

                // Add the new item to the repository
                _repository.Add(item);
                Console.WriteLine("Item added. Press any key to continue...");
                Console.ReadKey(true);
            }

            private static void ViewAllItems()
            {
                Console.Clear();
                Console.WriteLine("All items:");

                // Get all items from the repository and display them
                var items = _repository.GetAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }

            private static void ViewItemById()
            {
                Console.Clear();
                Console.Write("Enter item ID: ");
                int id = int.Parse(Console.ReadLine());

                // Get the item with the specified ID from the repository and display it
                var item = _repository.GetById(id);
                if (item != null)
                {
                    Console.WriteLine(item.ToString());
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }

            private static void EditItemById()
            {
                Console.Clear();
                Console.Write("Enter item ID: ");
                int id = int.Parse(Console.ReadLine());

                // Get the item with the specified ID from the repository and display it
                var item = _repository.GetById(id);
                if (item != null)
                {
                    Console.WriteLine("Enter new item details:");

                    // Update the properties of the item
                    foreach (var property in typeof(T).GetProperties())
                    {
                        Console.Write("{0} ({1}): ", property.Name, property.GetValue(item));
                        var value = Console.ReadLine();
                        if (!string.IsNullOrEmpty(value))
                        {
                            property.SetValue(item, Convert.ChangeType(value, property.PropertyType));
                        }
                    }

                    // Save the changes to the repository
                    _repository.Edit(item);
                    Console.WriteLine("Item updated. Press any key to continue...");
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }

                Console.ReadKey(true);
            }

            private static void DeleteItemById()
            {
                Console.Clear();
                Console.Write("Enter item ID: ");
                int id = int.Parse(Console.ReadLine());

                // Get the item with the specified ID from the repository and display it
                var item = _repository.GetById(id);
                if (item != null)
                {
                    // Delete the item from the repository
                    _repository.Delete(item);
                    Console.WriteLine("Item deleted. Press any key to continue...");
                }
                else
                {
                    Console.WriteLine("Item not found.");
                }

                Console.ReadKey(true);
            }
        }
    }