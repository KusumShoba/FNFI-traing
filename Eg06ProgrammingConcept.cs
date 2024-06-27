//Main pgm divided into fn, logically divided
//ip 1 sec, operation 1 sec

//Shift+Cursor== select
//Alt+Cursor==Many pointers
//Ctrl+D==select same words.

using System;
namespace SampleConApp
{
    class Arithematic{
        //take or give value somewhere i used this.
        public double FirstValue{get; set; }
        public double SecondtValue{get; set; }
        public string Operation{get; set; }

        public double performanceOperation(){
            switch (Operation)
                {
                    case "+":
                        return (FirstValue+SecondtValue);
                        

                    case "-":
                         return (FirstValue-SecondtValue);


                    case "*":
                        return (FirstValue*SecondtValue);

                    case "/":
                        return (FirstValue/SecondtValue);



                    default:
                     throw new Exception("Invalid choice");//jump stmt ,return 


                }
        }
            
        }
    class Eg06ProgrammingConcept
    {
        
        static double performanceOperation(double first ,double second, string operation)
        {
            Arithematic math = new Arithematic();//now i can maintain a history if needed ! So do instance here.
            math.FirstValue=first;
            math.SecondtValue=second;
            math.Operation=operation;

            return math.performanceOperation();
                

        }
        static void Main(string[] args){

            string stopSignal="";
            System.Console.WriteLine("Welcome to windows calculator ");
            do{
                // System.Console.WriteLine("Enter the 1st number ");
                // double first = double.Parse(Console.ReadLine());

                // System.Console.WriteLine("Enter the Choice operation as + , - , * , / ");
                // string operation = Console.ReadLine();

                // System.Console.WriteLine("Enter the 2nd number ");
                // double second = double.Parse(Console.ReadLine());

                var first = MyConsole.GetDouble("Enter the 1st number");
                var operation = MyConsole.GetString("Enter the Choice operation as + , - , * , / ");
                var second = MyConsole.GetDouble("Enter the 2nd number ");
        try{
                double result=performanceOperation(first,second,operation);
                System.Console.WriteLine("The result of the operation is" +result);
                stopSignal = MyConsole.GetString("Do You Want TO Continue ? Press Y for Yes and N for No");
       }    
       catch(Exception ex)
       {
                System.Console.WriteLine(ex.Message);

       }     
            }while(stopSignal.ToUpper() == "Y");
        }
    }
}