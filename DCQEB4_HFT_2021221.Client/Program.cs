//using DCQEB4_HFT_2021221.Data;
//using DCQEB4_HFT_2021221.Logic;
//using DCQEB4_HFT_2021221.Repository;
using DCQEB4_HFT_2021221.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using ConsoleTools;

namespace DCQEB4_HFT_2021221.Client
{

    class Program
    {
        static void Main(string[] args)
        {
            RestService restService = new RestService("http://localhost:50620");
            ConsoleMenu main = new ConsoleMenu(args, 0);
            ConsoleMenu depmenu = new ConsoleMenu(args,1);
            ConsoleMenu empmenu = new ConsoleMenu(args, 1);
            ConsoleMenu salmenu = new ConsoleMenu(args, 1);
            ConsoleMenu special = new ConsoleMenu(args, 1);
            main.Add("Department Menu", () => depmenu.Show());
            main.Add("Employee Menu", () => empmenu.Show());
            main.Add("Salary Menu", () => salmenu.Show());
            main.Add("Special Menu", () => special.Show());
            main.Add("Quit", ()=>main.CloseMenu()) ;

            depmenu.Add("Back to Main Menu", () => depmenu.CloseMenu());
            empmenu.Add("Back to Main Menu", () => empmenu.CloseMenu());
            salmenu.Add("Back to Main Menu", () => salmenu.CloseMenu());
            special.Add("Back to Main Menu", () => special.CloseMenu());
            depmenu.Add("List all department", () =>
            {
                var res = restService.Get<Department>("/department");
                foreach (var item in res)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadKey();
            });
            depmenu.Add("Find one deppartment", () =>
            {
                Console.WriteLine("I need an ID!");
                string input = Console.ReadLine();
                var res = restService.GetSingle<Department>("/department/"+input);
                Console.WriteLine(res.ToString());
                Console.ReadKey();
            });
            depmenu.Add("Add a Department", () =>
            {
                Console.WriteLine("WARNING! All change are final!");
                Console.Write("New Department name: ");
                string name=Console.ReadLine();
                Console.WriteLine("Type: ");
                Console.WriteLine("1) "+DepartmentType.It);
                Console.WriteLine("2) " + DepartmentType.Legal);
                Console.WriteLine("3) " + DepartmentType.Finance);
                Console.Write("Pick the number: ");
                DepartmentType departmentType = (DepartmentType)int.Parse(Console.ReadLine());
                Department newdep = new Department() {DepartmentName=name,Type=departmentType };
                restService.Post<Department>(newdep,"/department");
                Console.WriteLine("Done!");
                Console.ReadKey();
                
            });
            depmenu.Add("Delete Department", () =>
            {
                Console.WriteLine("WARNING! All change are final!");
                Console.WriteLine("WARNING! You can only delete departments with no employee!");
                Console.Write("I need an Id: ");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "/department");
                Console.WriteLine("Done!");
                Console.ReadKey();
            });
            depmenu.Add("Update Department", () =>
            {
                Console.WriteLine("WARNING! All change are final!");
                Console.WriteLine("WARNING! You can only update departments with no employees");
                Console.Write("I need an ID: ");
                string input = Console.ReadLine();
                var res = restService.Get<Department>(int.Parse(input),"/department");

                Console.Write("New Name: ");
                string newname = Console.ReadLine();
                Console.WriteLine("New Type: ");
                Console.WriteLine("1) " + DepartmentType.It);
                Console.WriteLine("2) " + DepartmentType.Legal);
                Console.WriteLine("3) " + DepartmentType.Finance);
                Console.Write("Pick the number: ");
                DepartmentType departmentType = (DepartmentType)int.Parse(Console.ReadLine());
                res.DepartmentName = newname;
                res.Type = departmentType;

                restService.Put<Department>(res, "/department");
                Console.WriteLine("Done!");
                Console.ReadKey();
            });
            empmenu.Add("List all employee", () =>
            {
                var res = restService.Get<Employee>("/employee");
                foreach (var item in res)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadKey();
            });
            empmenu.Add("Find one employee", () =>
            {
                Console.WriteLine("I need an ID!");
                string input = Console.ReadLine();
                var res = restService.GetSingle<Employee>("/employee/" + input);
                Console.WriteLine(res.ToString());
                Console.ReadKey();
            });
            empmenu.Add("Add a employee", () =>
            {
                Console.WriteLine("WARNING! All change are final!");
                Console.Write("New employee name: ");
                string name = Console.ReadLine();
                Console.Write("New employee email: ");
                string email= Console.ReadLine();
                var res = restService.Get<Department>("/department");
                foreach (var item in res)
                {
                    Console.WriteLine("Existing Department ID: "+item.ID+"\t and Department name: "+item.DepartmentName);
                }
                Console.Write("New employee Department ID: ");
                int depid = int.Parse(Console.ReadLine());
                Employee employee = new Employee() {Name=name, Email=email,DepartmentID=depid};
                restService.Post<Employee>(employee, "/employee");
                Console.WriteLine("Done!");
                Console.ReadKey();

            });
            empmenu.Add("Delete employee", () =>
            {
                Console.WriteLine("WARNING! All change are final!");
                Console.WriteLine("WARNING! You can only delete employees with no salaries!");
                Console.Write("I need an Id: ");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "/employee");
                Console.WriteLine("Done!");
                Console.ReadKey();
            });
            empmenu.Add("Update Employee", () =>
            {
                Console.WriteLine("WARNING! All change are final!");
                Console.WriteLine("WARNING! You can only update employees with no salaries!");
                Console.Write("I need an ID: ");
                string input = Console.ReadLine();
                var res = restService.Get<Employee>(int.Parse(input), "/employee");

                Console.Write("New name: ");
                string name = Console.ReadLine();
                Console.Write("New email: ");
                string email = Console.ReadLine();
                var res2 = restService.Get<Department>("/department");
                foreach (var item in res2)
                {
                    Console.WriteLine("Existing Department ID: " + item.ID + "\t and Department name: " + item.DepartmentName);
                }
                Console.Write("New Department ID: ");
                int depid = int.Parse(Console.ReadLine());
                res.Name = name;
                res.Email = email;
                res.DepartmentID = depid;

                restService.Put<Employee>(res, "/employee");
                Console.WriteLine("Done!");
                Console.ReadKey();
            });
            salmenu.Add("List all salary", () =>
            {
                var res = restService.Get<Salary>("/salary");
                foreach (var item in res)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadKey();
            });
            salmenu.Add("Find one salary", () =>
            {
                Console.WriteLine("I need an ID!");
                string input = Console.ReadLine();
                var res = restService.GetSingle<Salary>("/salary/" + input);
                Console.WriteLine(res.ToString());
                Console.ReadKey();
            });
            salmenu.Add("Create Salary", () =>
            {
                Console.WriteLine("WARNING! All change are final!");
                Console.WriteLine("Salary date created for today!");
                DateTime dateTime = DateTime.Today;
                Console.Write("Base Salary($): ");
                int basesalary = int.Parse(Console.ReadLine());
                Console.Write("Bonus(Can be 0) : ");
                int bonus = int.Parse(Console.ReadLine());
                var res = restService.Get<Employee>("/employee");
                foreach (var item in res)
                {
                    Console.WriteLine("Employee Name: "+item.Name+"\tConnected id: "+item.ID);
                }
                Console.Write("Salary Employee ID: ");
                int empid = int.Parse(Console.ReadLine());
                Salary salary = new Salary() {Date=dateTime,EmployeeID=empid,Bonus=bonus,BaseSalary=basesalary };
                restService.Post<Salary>(salary, "/salary");
                Console.WriteLine("Done!");
                Console.ReadKey();

            });
            salmenu.Add("Delete salary", () =>
            {
                Console.WriteLine("WARNING! All change are final!");
                Console.Write("I need an Id: ");
                int id = int.Parse(Console.ReadLine());
                restService.Delete(id, "/salary");
                Console.WriteLine("Done!");
                Console.ReadKey();
            });
            salmenu.Add("Update a Salary", () =>
            {
                Console.WriteLine("WARNING! All change are final!");
                Console.Write("I need an ID: ");
                string input = Console.ReadLine();
                var res = restService.Get<Salary>(int.Parse(input), "/salary");
                Console.WriteLine("Time and date can not be Updated!");
                Console.Write("Base Salary($): ");
                int basesalary = int.Parse(Console.ReadLine());
                Console.WriteLine("Bonus(Can be 0) : ");
                int bonus = int.Parse(Console.ReadLine());
                var res2 = restService.Get<Employee>("/employee");
                foreach (var item in res2)
                {
                    Console.WriteLine("Employee Name: " + item.Name + "\tConnected id: " + item.ID);
                }
                Console.Write("Salary Employee ID: ");
                int empid = int.Parse(Console.ReadLine());
                res.BaseSalary = basesalary;
                res.Bonus = bonus;
                res.EmployeeID = empid;
                restService.Put<Salary>(res, "/salary");
                Console.WriteLine("Done!");
                Console.ReadKey();
            });
            special.Add("All department Cost", () =>
            {
                var res = restService.Get<DepartmentCost>("/stat/GetDepartmentCosts");
                foreach (var item in res)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadLine();
            });
            main.Show();
            //HrDbContext data = new HrDbContext();
            //data.Employees.Select(x => x.Name).ToConsole("1");
            //data.Departments.Select(x => x.DepartmentName).ToConsole("2");
            //data.Salaries.Select(x => x.ID).ToConsole("3");
            //DepartmentRepository departmentRepository = new DepartmentRepository(data);
            //EmployeeRepository employeeRepository = new EmployeeRepository(data);
            //SalaryRepository salaryRepository = new SalaryRepository(data);
            //DepartmentLogic departmentLogic = new DepartmentLogic(departmentRepository,employeeRepository,salaryRepository);
            //var a=departmentLogic.DepartmentCost();
            //foreach (var item in a)
            //{
            //    Console.WriteLine(item.DepartmentName+" avarge cost is: "+item.AvargePrice+"$/mounth");
            //}
        }
    }
}
