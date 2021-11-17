using DCQEB4_HFT_2021221.Data;
using DCQEB4_HFT_2021221.Logic;
using DCQEB4_HFT_2021221.Repository;
using System.Linq;
using System;
using System.Collections.Generic;

namespace DCQEB4_HFT_2021221.Client
{
    static class Operations
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string header)
        {
            Console.WriteLine($"************* {header} ************");
            foreach (var item in input) Console.WriteLine(item);
            Console.WriteLine($"************* {header} ************");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            HrDbContext data = new HrDbContext();
            data.Employees.Select(x => x.Name).ToConsole("1");
            data.Departments.Select(x => x.DepartmentName).ToConsole("2");
            data.Salaries.Select(x => x.ID).ToConsole("3");
            DepartmentRepository departmentRepository = new DepartmentRepository(data);
            EmployeeRepository employeeRepository = new EmployeeRepository(data);
            SalaryRepository salaryRepository = new SalaryRepository(data);
            DepartmentLogic departmentLogic = new DepartmentLogic(departmentRepository,employeeRepository,salaryRepository);
            var a=departmentLogic.DepartmentCost();
            foreach (var item in a)
            {
                Console.WriteLine(item.DepartmentName+" avarge cost is: "+item.AvargePrice+"$/mounth");
            }
        }
    }
}
