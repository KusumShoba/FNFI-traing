//Finance app to calculate the EMI for a given principal amt with a certain interest rate and tern
//it shd also calculate the RD amt and provide the final amt , use C# progamming language

using System;

public class LoanCalculator
{
    public static void Main(string[] args)
    {
        // Get user input for principal, interest rate, and time in years
        var principal= MyConsole.GetDouble("Enter the principal amount:");

        var interestRate= MyConsole.GetDouble("Enter the annual interest rate (e.g., for 10% enter 0.1):");

        var timeInYears= MyConsole.GetDouble("Enter the loan term in years:");


        // Calculate EMI, RD amount, and final amount
        var loanDetails = CalculateEmiRd(principal, interestRate, timeInYears);

        // Display the results
        Console.WriteLine("EMI: {0:0.00}", loanDetails.EMI);
        Console.WriteLine("RD amount: {0:0.00}", loanDetails.RDamount);
        Console.WriteLine("Final amount: {0:0.00}", loanDetails.FinalAmount);
    }

    public static LoanDetails CalculateEmiRd(double principal, double interestRate, double timeInYears)
    {
        // Convert interest rate to monthly rate
        double monthlyInterestRate = interestRate / 12;

        // Calculate the number of monthly payments
        int numberOfPayments = (int)(timeInYears * 12);

        // Calculate EMI using the EMI formula
        double emi = (principal * monthlyInterestRate) / (1 - Math.Pow(1 + monthlyInterestRate, -numberOfPayments));

        // Calculate the RD amount required to pay the EMI each month
        double rdAmount = emi / (1 + monthlyInterestRate);

        // Calculate the final amount (principal + total interest paid)
        double totalInterestPaid = emi * numberOfPayments - principal;
        double finalAmount = principal + totalInterestPaid;

        return new LoanDetails(emi, rdAmount, finalAmount);
    }
}

public class LoanDetails
{
    public double EMI { get; set; }
    public double RDamount { get; set; }
    public double FinalAmount { get; set; }

    public LoanDetails(double emi, double rdAmount, double finalAmount)
    {
        EMI = emi;
        RDamount = rdAmount;
        FinalAmount = finalAmount;
    }
}