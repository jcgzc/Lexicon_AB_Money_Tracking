# Lexicon_AB_Money_Tracking

# Income/Expense Manager

This application allows you to manage a collection of income and expense items, which can be added, edited, removed, displayed, and sorted. You can also filter by income or expense types and store/retrieve the items to/from a file.

### Features:
- **Manage Items**: Add, edit, or remove income and expense items.
- **Sort Items**: Sort by title, amount, or month.
- **Filter Items**: Display only income items or only expense items.
- **Save and Load**: Items are saved to a file and can be loaded from the file when the application starts.
- **Error Handling**: Basic error handling is implemented to manage user input errors and file-related exceptions.

### Class Structure:
- **Item** (Abstract Class): Represents a generic item with properties such as `Title`, `Amount`, and `Date`. The `GetItemType()` method is abstract and must be implemented in subclasses.
- **Income**: Inherits from `Item`, representing an income item. Implements `GetItemType()` to return "Income".
- **Expense**: Inherits from `Item`, representing an expense item. Implements `GetItemType()` to return "Expense".
- **Program**: Main class that drives the application, implements the `IItemStorage` interface for saving and loading data. It manages the user interface and the list of items.
- **IItemStorage**: Interface for saving and loading items from a file.

### How to Use:
1. **Run the Application**: Execute the `Program` class to launch the text-based user interface.
2. **Menu Options**:
   - **Add Item**: Enter a title, amount, month, and whether it's an income or expense.
   - **Edit Item**: Modify an existing item's title, amount, or month.
   - **Remove Item**: Remove an item from the list by specifying its index.
   - **Show Items**: View all the items in the collection.
   - **Sort Items**: Sort items by title, amount, or date.
   - **Filter Items**: Display only income items or only expense items.
   - **Save Items**: Save the list of items to a file.
   - **Exit**: Close the application.

3. **Data Persistence**: All items are saved to a text file called `items.txt`. This file is automatically loaded when the program starts, allowing you to retain your data between sessions.

### File Format (`items.txt`):
The file stores each item in a simple text format:
```
Title | Amount | Month Year | Income/Expense
```
Example:
```
Salary | 2000.00 | December 2024 | Income
Groceries | 150.00 | December 2024 | Expense
```

### Requirements:
- .NET 6.0 or higher.
- A terminal/console window to run the application.

### Error Handling:
- The program uses `try-catch` blocks to handle common exceptions like invalid input or file errors. If an error occurs, a message will be displayed with a description of the problem.

### Example Output:

```
Income/Expense Manager
1. Add Item
2. Edit Item
3. Remove Item
4. Show Items
5. Sort Items
6. Filter Items
7. Save Items
8. Exit
Choose an option: 1

Enter title: Salary
Enter amount: 2000
Enter month (e.g., December): December
Is this an income (yes/no): yes

Item added successfully.
```

### Troubleshooting:
- **Invalid Input**: If the user enters invalid data (e.g., a non-numeric amount), the program will catch the error and display an error message.
- **File Issues**: If there's a problem reading or writing the `items.txt` file (e.g., file not found), an error message will be displayed, and the program will handle the exception gracefully.

---

### Conclusion:
This `Income/Expense Manager` provides a simple, effective way to track your financial items. Whether you're managing personal finance or tracking business income/expenses, the program allows for easy addition, editing, and sorting of items. Data is persistently stored in a file, ensuring your information is available even after closing the application.

---

This `README.txt` should provide a clear understanding of how to use the program and its features.