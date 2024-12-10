
// Income class inherits from Item
class Income : Item
{
    public Income(string title, decimal amount, DateTime date)
        : base(title, amount, date)
    {
    }

    public override string GetItemType()
    {
        return "Income";
    }
}
