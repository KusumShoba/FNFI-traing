//instatiatind to Derived ; datatype is base =====> BaseClass cls = new DerivedClass();
//Object Slicing
//Same happens in virtual not mentioned 
//then I do typpe casting
//Derived cls i want derived
//safe typecasting
//alt + (UpArrow) moves the line up

using System;

//A class is closed for modification


class BaseClass {
    public virtual void TestFunc()
    {
        System.Console.WriteLine("Test Function From Base");
    }


    public void NonOverridableFunc(){
        System.Console.WriteLine("This func is from Base only");
    }
}


//If u want to modify a method u shd go for inheritence. The Base class method must be virtual if u want to override(change) the method.



class DerivedClass : BaseClass 
{
    public override void TestFunc()
    {
        System.Console.WriteLine("Test function from derived class");
    }

    //this is more like function which is sliced to the base type.

    public void NonOverridableFunction()
    {
        System.Console.WriteLine("This function is derived which hides the base version");
    }

    public void SecondTestFunction()
    {
        Console.WriteLine("Second Test Function From Derived Class");
    }
}

class FactoryClass
{
    public static BaseClass CreateObject(string choice)
    {
        if(choice=="Base") 
            return new BaseClass();


        else if(choice=="Derived")
            return new DerivedClass(); // i mean object is created for this class


        else 
            throw new Exception("Invalid choice");
    }
}




class MainClass

{
    static void firstExample()
    {
        //The derived version will be called only when the method is overriden.
        Console.WriteLine("Enter the type you want to create : Base or Derived");

        var obj = FactoryClass.CreateObject(Console.ReadLine());

        obj.TestFunc();
    }
    static void Main(string[] args)
    {
        //firstExample();

        BaseClass cls = new DerivedClass();
        //Do this when U want to access the new members of the derived class that is not defined in the base.
        if(cls is DerivedClass)
        {
            //DerivedClass temp = (DerivedClass)cls;
            //OR
            var temp= cls as DerivedClass;
            temp.SecondTestFunction();
            temp.NonOverridableFunction();
        }
        cls.TestFunc();
        cls.NonOverridableFunction();  //call the base version ....
        //cls.SecondTestFunction();

    }
}