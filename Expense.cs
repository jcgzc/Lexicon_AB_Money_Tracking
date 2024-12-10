
// Expense class inherits from Item
class Expense : Item
{
    public Expense(string title, decimal amount, DateTime date)
        : base(title, amount, date)
    {
    }

    public override string GetItemType()
    {
        return "Expense";
    }
}
