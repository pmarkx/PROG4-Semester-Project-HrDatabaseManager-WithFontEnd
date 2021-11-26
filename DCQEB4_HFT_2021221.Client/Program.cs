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
            ConsoleMenu consoleMenu = new ConsoleMenu();

            consoleMenu.Add("List all department", () =>
            {
                var res = restService.Get<Department>("/department");
                foreach (var item in res)
                {
                    Console.WriteLine(new { id = item.ID, name = item.DepartmentName, type = item.Type });
                }
                Console.ReadLine();
            });
            consoleMenu.Show();
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
