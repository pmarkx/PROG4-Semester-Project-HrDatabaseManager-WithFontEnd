using DCQEB4_HFT_2021221.Models;
using System;
using DCQEB4_HFT_2021221.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        IEmployeeRepository EmpRepo;
        ISalaryRepository SalRepo;
        public EmployeeLogic(IEmployeeRepository employeeRepository,ISalaryRepository salary)
        {
            EmpRepo = employeeRepository;
            SalRepo = salary;
        }

        public Employee BiggestSalaryEmployee()
        {
            var x = SalRepo.GetAll();
            int max = 0;
            Employee employee = new Employee();
            foreach (var item in x)
            {
                if (item.BaseSalary>max)
                {
                    max = item.BaseSalary;
                    employee = item.Employee;
                }
            }
            return employee;
        }

        public void Create(Employee newEmp)
        {
            //if (newEmp.ID < 1)
            //{
            //    throw new ArgumentException("WrongID");
            //}
            if (newEmp.Name.Length<=3)
            {
                throw new ArgumentException("Name is invalid");
            }
            if (!newEmp.Email.Contains("@"))
            {
                throw new ArgumentException("Wrong Email");
            }
            if (newEmp.DepartmentID<1)
            {
                throw new ArgumentException("Wrong Department ID");
            }
            EmpRepo.Create(newEmp);
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("WrongID");
            }
            EmpRepo.Delete(id);
        }

        public void Delete(Employee delete)
        {
            if (delete.ID < 1)
            {
                throw new ArgumentException("WrongID");
            }
            EmpRepo.Delete(delete);
        }

        public IList<DepartmentCost> EmployeeAvargeSalary()
        {

            var a = from x in SalRepo.GetAll()
                    group x by new { x.EmployeeID, x.Employee.Name } into qq
                    select new DepartmentCost() { DepartmentName = qq.Key.Name, AvargeCost = qq.Average(x => x.BaseSalary) };
            return a.ToList();
        }

        public IList<Employee> GetAll()
        {
            return EmpRepo.GetAll().ToList();
        }

        public Employee GetOne(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("WrongID");
            }
            return EmpRepo.GetOne(id);
        }

        public void Update(Employee updatedEmp)
        {
            if (updatedEmp.ID < 1)
            {
                throw new ArgumentException("WrongID");
            }
            EmpRepo.Update(updatedEmp);
        }
    }
}
