
// Abstract class representing a generic Item
abstract class Item
{
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Item(string title, decimal amount, DateTime date)
    {
        Title = title;
        Amount = amount;
        Date = date;
    }

    // Abstract method to get the type of the item (Income or Expense)
    public abstract string GetItemType();

    // Common method for displaying the item
    public override string ToString()
    {
        return $"{Title} | {Amount:C} | {Date:MMMM yyyy} | {GetItemType()}";
    }
}
