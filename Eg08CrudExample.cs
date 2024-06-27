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
    static void Main(string[] args)
    {
        ExpenseManager ex=new ExpenseManager();
        ex.AddNewExpense(ex);
        ex.UpdateExpenses(ex);
        ex.FindById(id);
        // ex.Id=1;
        // ex.Description="Grocery";
        // ex.Amt=5000;
        // ex.Date=DateTime.Today;


// //Creating few more objects of the expenses and iterating through them
       
//         Expense ex2=new Expense();
//         ex2.Id=2;
//         ex2.Description="Luxtury";
//         ex2.Amt=50000;
//         ex2.Date=DateTime.Today;

//         Expense ex3=new Expense();
//         ex3.Id=3;
//         ex3.Description="Needs";
//         ex3.Amt=25000;
//         ex3.Date=DateTime.Today;


        // foreach(var expense in ex){
        // Console.WriteLine("***********Expenses Details*****************");
        // Console.WriteLine("{0} is the id"+expense.Id);
        // Console.WriteLine("{0} is the Description"+expense.Description);
        // Console.WriteLine("{0} is the Amt"+expense.Amt);
        // Console.WriteLine("{0} is the Date"+expense.Date);
        // }

        // string choice=Console.ReadLine();

        // switch(choice)
        // {
        //     case "N":
        //     AddNewExpense(ex);
        //     break;

        //     case "F":
        //     FindById(ex);
        //     break;

        //     case "U":
        //     UpdateExpenses(int id);
        //     break;

        //     default:
        //     Console.WriteLine("Invalid choice");
        //     break;
        // }


    }
}