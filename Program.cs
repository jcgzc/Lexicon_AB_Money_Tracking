using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Interface for saving and loading items from a file
interface IItemStorage
{
    void LoadItems();
    void SaveItems();
}

class Program : IItemStorage
{
    private static List<Item> items = new List<Item>();

    static void Main(string[] args)
    {
        try
        {
            Program program = new Program();
            program.LoadItems();
            bool exit = false;

            while (!exit)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        EditItem();
                        break;
                    case "3":
                        RemoveItem();
                        break;
                    case "4":
                        ShowItems();
                        break;
                    case "5":
                        SortItems();
                        break;
                    case "6":
                        FilterItems();
                        break;
                    case "7":
                        program.SaveItems();
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // Menu options
    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Income/Expense Manager");
        Console.WriteLine(">> 1. Add Item");
        Console.WriteLine(">> 2. Edit Item");
        Console.WriteLine(">> 3. Remove Item");
        Console.WriteLine(">> 4. Show Items");
        Console.WriteLine(">> 5. Sort Items");
        Console.WriteLine(">> 6. Filter Items");
        Console.WriteLine(">> 7. Save Items");
        Console.WriteLine(">> 8. Exit");
        Console.Write("Choose an option: ");
    }

    // Add a new item (Income or Expense)
    static void AddItem()
    {
        try
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();

            Console.Write("Enter amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter month (e.g., December): ");
            string month = Console.ReadLine();

            DateTime date = DateTime.ParseExact(month, "MMMM", System.Globalization.CultureInfo.InvariantCulture);

            Console.Write("Is this an income (yes/no): ");
            bool isIncome = Console.ReadLine().ToLower() == "yes";

            Item item = isIncome ? new Income(title, amount, date) : new Expense(title, amount, date);

            items.Add(item);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Edit an existing item
    static void EditItem()
    {
        ShowItems();
        try
        {
            Console.Write("Enter the index of the item to edit: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index >= 0 && index < items.Count)
            {
                Console.Write("Enter new title: ");
                string title = Console.ReadLine();

                Console.Write("Enter new amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter new month (e.g., December): ");
                string month = Console.ReadLine();

                DateTime date = DateTime.ParseExact(month, "MMMM", System.Globalization.CultureInfo.InvariantCulture);

                Console.Write("Is this an income (yes/no): ");
                bool isIncome = Console.ReadLine().ToLower() == "yes";

                items[index] = isIncome ? new Income(title, amount, date) : new Expense(title, amount, date);
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Remove an item
    static void RemoveItem()
    {
        ShowItems();
        try
        {
            Console.Write("Enter the index of the item to remove: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index >= 0 && index < items.Count)
            {
                items.RemoveAt(index);
                Console.WriteLine("Item removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Show all items
    static void ShowItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("No items available.");
            return;
        }

        Console.WriteLine("\nItems:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }
        Console.ReadKey();   
    }

    // Sort items by Title, Amount, or Date
    static void SortItems()
    {
        Console.WriteLine("Sort by (1) Title, (2) Amount, (3) Date");
        string sortOption = Console.ReadLine();

        try
        {
            switch (sortOption)
            {
                case "1":
                    items = items.OrderBy(i => i.Title).ToList();
                    break;
                case "2":
                    items = items.OrderBy(i => i.Amount).ToList();
                    break;
                case "3":
                    items = items.OrderBy(i => i.Date).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.WriteLine("Items sorted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Filter items by income or expense
    static void FilterItems()
    {
        Console.WriteLine("Filter by (1) Income, (2) Expense");
        string filterOption = Console.ReadLine();

        try
        {
            IEnumerable<Item> filteredItems = filterOption switch
            {
                "1" => items.Where(i => i is Income),
                "2" => items.Where(i => i is Expense),
                _ => throw new InvalidOperationException("Invalid filter option.")
            };

            Console.WriteLine("\nFiltered Items:");
            foreach (var item in filteredItems)
            {
                Console.WriteLine(item);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Load items from a file
    public void LoadItems()
    {
        try
        {
            if (File.Exists("items.txt"))
            {
                var lines = File.ReadAllLines("items.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        string title = parts[0].Trim();
                        decimal amount = decimal.Parse(parts[1].Trim(), System.Globalization.CultureInfo.InvariantCulture);
                        DateTime date = DateTime.ParseExact(parts[2].Trim(), "MMMM yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        bool isIncome = parts[3].Trim() == "Income";

                        Item item = isIncome ? new Income(title, amount, date) : new Expense(title, amount, date);
                        items.Add(item);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading items: {ex.Message}");
        }
    }

    // Save items to a file
    public void SaveItems()
    {
        try
        {
            var lines = items.Select(i => $"{i.Title} | {i.Amount} | {i.Date:MMMM yyyy} | {i.GetItemType()}");
            File.WriteAllLines("items.txt", lines);
            Console.WriteLine("Items saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving items: {ex.Message}");
        }
    }
}
