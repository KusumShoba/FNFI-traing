//Repository Collection Pattern


using System;
using System.Collections.Generic;
class Expense
{
    public int Id{get; set;}
    public String Description{get; set;}
    public double Amt{get; set;}
    public DateTime Date{get; set;}

}

class ExpenseManager
{
    

    private List<Expense> exs=new List<Expense>();

    public void AddNewExpense(Expense expen)
    {
        exs.Add(expen);
    }

    public void UpdateExpenses(Expense expen)
    {
        for(int i=0; i< exs.Count; i++)
        {
            if(exs[i] != null && exs[i].Id == expen.Id)
            {
                exs[i].Description=expen.Description;
                exs[i].Amt=expen.Amt;
                break;
            }
        }throw new Exception("No such id to update");
    }

    public Expense FindById(int id)
    {
        for(int i=0;i<exs.Count; i++)
        {
            if(exs[i]!=null && exs[i].Id==id)
            {
                return exs[i];
            }
        }
        return null;
    }
}

class Eg08
{
    ExpenseManager ex=new ExpenseManager();
    Console.WriteLine("Enter ur choice :");
    Console.WriteLine("1. N :- Add new element");
    Console.WriteLine("2. F :- Find the element by Id");
    Console.WriteLine("3. U :- Update the element");
    string choice=Console.ReadLine();

    switch (choice)
            {
                case "N":
                    Console.WriteLine("Enter Id:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Description:");
                    string description = Console.ReadLine();
                    Console.WriteLine("Enter Amount:");
                    double amount = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Date (yyyy-MM-dd):");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    Expense newExpense = new Expense
                    {
                        Id = id,
                        Description = description,
                        Amt = amount,
                        Date = date
                    };

                    manager.AddNewExpense(newExpense);
                    Console.WriteLine("Expense added successfully.");
                    break;

                case "F":
                    Console.WriteLine("Enter Id to find:");
                    int findId = int.Parse(Console.ReadLine());
                    Expense foundExpense = manager.FindById(findId);
                    if (foundExpense != null)
                    {
                        Console.WriteLine($"Found Expense: Id={foundExpense.Id}, Description={foundExpense.Description}, Amount={foundExpense.Amt}, Date={foundExpense.Date}");
                    }
                    else
                    {
                        Console.WriteLine("Expense not found.");
                    }
                    break;

                case "U":
                    Console.WriteLine("Enter Id to update:");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter New Description:");
                    string newDescription = Console.ReadLine();
                    Console.WriteLine("Enter New Amount:");
                    double newAmount = double.Parse(Console.ReadLine());

                    Expense updatedExpense = new Expense
                    {
                        Id = updateId,
                        Description = newDescription,
                        Amt = newAmount
                    };

                    try
                    {
                        manager.UpdateExpenses(updatedExpense);
                        Console.WriteLine("Expense updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "Q":
                    Console.WriteLine("Quitting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
}
