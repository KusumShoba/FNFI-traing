using System;
namespace SampleConApp{


class CalcEMI {

    public double Principal{get; set;}
    public double Interest{get; set; }
    public double Time{get; set; }


    public double CalculateEMI(){
        // Convert interest rate to monthly rate
        double monthlyInterestRate = Interest / 12;

        // Calculate the number of monthly payments
        int numberOfPayments = (int)(Time * 12);

        // Calculate EMI using the EMI formula
        double emi = (Principal * monthlyInterestRate) / (1 - Math.Pow(1 + monthlyInterestRate, -numberOfPayments));

        return emi;
    }
    
}
class CalcRD {

    public double Principal{get; set;}
    public double Interest{get; set; }
    public double Time{get; set; }


    public double CalculateFinalAmount(){
        // Convert interest rate to monthly rate
        double monthlyInterestRate = Interest / 12;

        // Calculate the number of monthly payments
        int numberOfPayments = (int)(Time * 12);

        // Calculate Final AMount after all the payments are made
        double rd = ((Principal * monthlyInterestRate) / (1 - Math.Pow(1 + monthlyInterestRate, -numberOfPayments)))/(1 + monthlyInterestRate);

        return rd;
    }
    
}


public class FinanceProgram{
static double takeInputs(double principal ,double interestRate, double timeInYears)
{
    CalcEMI emi=new CalcEMI();
    emi.Principal=principal;
    emi.Interest=interestRate;
    emi.Time=timeInYears;
    return emi.CalculateEMI();  
}

static double takeInputsRD(double principal ,double interestRate, double timeInYears){
    CalcRD rd=new CalcRD();
    rd.Principal=principal;
    rd.Interest=interestRate;
    rd.Time=timeInYears;
    return rd.CalculateFinalAmount();
}

    public static void Main(string[] args){
        var principal= MyConsole.GetDouble("Enter the principal amount:");

        var interestRate= MyConsole.GetDouble("Enter the annual interest rate (e.g., for 10% enter 0.1):");

        var timeInYears= MyConsole.GetDouble("Enter the loan term in years:");

        Console.WriteLine("**********Do you want to calculate the EMI or RD ?***********");
        Console.WriteLine("Press 1 for EMI");
        Console.WriteLine("Press 2 for RD");
        int opt = int.Parse(Console.ReadLine());
        double res;


        switch(opt){
            case 1:
                res=emi.takeInputs();
                return res;

            case 2:
                return rd.takeInputsRD();

            default:
                return null;

        }

        

    }
}
}