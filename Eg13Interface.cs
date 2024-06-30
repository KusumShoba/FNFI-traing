/*
Notes on Interfaces:
Like abstract classes, interfaces cannot be used to create objects (in the example above, it is not possible to create an "IAnimal" object in the Program class)
Interface methods do not have a body - the body is provided by the "implement" class
On implementation of an interface, you must override all of its methods
Interfaces can contain properties and methods, but not fields/variables
Interface members are by default abstract and public
An interface cannot contain a constructor (as it cannot be used to create objects)
*/

﻿using System;
using System.Configuration;

/*
 * An interface is an entity that contains only abstract methods in them. 
 * The methods of the interface are always public. 
 * The Class that implements an interface must implement all the methods of the interface. They can however redeclare the method as abstract and make itself an Abstract class. The access specifier for the implemented methods must be public.
 * The idea of the interface is to enforce a rule to implement all the methods like a contract, the contract is the interface and enforcing is done by the implementor classes. 
 * Interfaces are the basis for most of the Software frameworks that are available in the computer software industry.  
 * inter
 */
namespace SampleConApp
{
    interface IEmployeeManager
    {
         void AddEmployee(Employee employee);//(C)
        void RemoveEmployee(int empId);//D
        void UpdateEmployee(int empId, Employee employee);//U
        Array GetAllEmployees();//R        
    }

    class OracleDbEmployeeManager : IEmployeeManager
    {
        public void AddEmployee(Employee employee)
        {
            Console.WriteLine("Employee added to Oracle Server database");
        }

        public Array GetAllEmployees()
        {
            Console.WriteLine("All Employees are retrieved from Oracle Server database");
            return new Employee[0];
        }

        public void RemoveEmployee(int empId)
        {
            Console.WriteLine("Employee removed From Oracle Server database");
        }

        public void UpdateEmployee(int empId, Employee employee)
        {
            Console.WriteLine($"Employee with Id {empId} is updated to Oracle Server database");

        }
    }
    class SqlDBEmployeeManager : IEmployeeManager
    {
         public void AddEmployee(Employee employee)
        {
            Console.WriteLine("Employee added to Sql Server database");
        }

        public Array GetAllEmployees()
        {
            Console.WriteLine("All Employees are retrieved from Sql Server database");
            return new Employee[0];
        }

        public void RemoveEmployee(int empId)
        {
            Console.WriteLine("Employee removed From Sql Server database");
        }

        public void UpdateEmployee(int empId, Employee employee)
        {
            Console.WriteLine($"Employee with Id {empId} is updated to Sql Server database");

        }
    }

    class EmployeeFactory
    {
        public static IEmployeeManager CreateEmployeeManager()
        {
            string type = ConfigurationManager.AppSettings["DbType"];
            switch (type)
            {
                case "Sql": return new SqlDBEmployeeManager();
                case "Oracle": return new OracleDbEmployeeManager();
                default: throw new NotImplementedException();
            }
        }
    }
    internal class Ex12_InterfaceExample
    {
        static IEmployeeManager mgr;
        static void Main(string[] args)
        {
            mgr = EmployeeFactory.CreateEmployeeManager();
            mgr.AddEmployee(new Employee());
            mgr.AddEmployee(new Employee());
            mgr.AddEmployee(new Employee());
            mgr.AddEmployee(new Employee());
            Console.ReadKey();  
        }
    }
}
//Todo: Create a Menu Driven Program that allows the User to select an option of the prefered Crud Operation and appropriately performs that action. It should be a continueous running app which closes only on request. It should not terminate abruptly.


using System;
using System.Collections.Generic;
using System.Configuration;

namespace SampleConApp
{
    interface IEmployeeManager
    {
        void AddEmployee(Employee employee);
        void RemoveEmployee(int empId);
        void UpdateEmployee(int empId, Employee employee);
        Array GetAllEmployees();
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    class OracleDbEmployeeManager : IEmployeeManager
    {
        public void AddEmployee(Employee employee)
        {
            Console.WriteLine("Employee added to Oracle Server database");
        }

        public Array GetAllEmployees()
        {
            Console.WriteLine("All Employees are retrieved from Oracle Server database");
            return new Employee[0];
        }

        public void RemoveEmployee(int empId)
        {
            Console.WriteLine("Employee removed From Oracle Server database");
        }

        public void UpdateEmployee(int empId, Employee employee)
        {
            Console.WriteLine($"Employee with Id {empId} is updated to Oracle Server database");
        }
    }

    class SqlDBEmployeeManager : IEmployeeManager
    {
        public void AddEmployee(Employee employee)
        {
            Console.WriteLine("Employee added to Sql Server database");
        }

        public Array GetAllEmployees()
        {
            Console.WriteLine("All Employees are retrieved from Sql Server database");
            return new Employee[0];
        }

        public void RemoveEmployee(int empId)
        {
            Console.WriteLine("Employee removed From Sql Server database");
        }

        public void UpdateEmployee(int empId, Employee employee)
        {
            Console.WriteLine($"Employee with Id {empId} is updated to Sql Server database");
        }
    }

    class EmployeeFactory
    {
        public static IEmployeeManager CreateEmployeeManager()
        {
            string type = ConfigurationManager.AppSettings["DbType"];
            switch (type)
            {
                case "Sql": return new SqlDBEmployeeManager();
                case "Oracle": return new OracleDbEmployeeManager();
                default: throw new NotImplementedException();
            }
        }
    }

    internal class Ex12_InterfaceExample
    {
        static IEmployeeManager mgr;

        static void Main(string[] args)
        {
            mgr = EmployeeFactory.CreateEmployeeManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Remove Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Get All Employees");
                Console.WriteLine("5. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        RemoveEmployee();
                        break;
                    case "3":
                        UpdateEmployee();
                        break;
                    case "4":
                        GetAllEmployees();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddEmployee()
        {
            Console.WriteLine("Enter Employee ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Employee Department:");
            string department = Console.ReadLine();

            Employee emp = new Employee { Id = id, Name = name, Department = department };
            mgr.AddEmployee(emp);
        }

        static void RemoveEmployee()
        {
            Console.WriteLine("Enter Employee ID to remove:");
            int id = int.Parse(Console.ReadLine());
            mgr.RemoveEmployee(id);
        }

        static void UpdateEmployee()
        {
            Console.WriteLine("Enter Employee ID to update:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new Employee Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter new Employee Department:");
            string department = Console.ReadLine();

            Employee emp = new Employee { Id = id, Name = name, Department = department };
            mgr.UpdateEmployee(id, emp);
        }

        static void GetAllEmployees()
        {
            Array employees = mgr.GetAllEmployees();
            Console.WriteLine("Retrieved Employees:");
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}");
            }
        }
    }
}
