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
        public EmployeeLogic(IEmployeeRepository employeeRepository)
        {
            EmpRepo = employeeRepository;
        }

        public void ChangeDepartment(int id, int NewDepID)
        {
            if (id < 1||NewDepID<1)
            {
                throw new ArgumentException("WrongID");
            }
            EmpRepo.ChangeDepartment(id, NewDepID);
        }

        public void ChangeEmail(int id, string NewEmail)
        {
            if (id < 1)
            {
                throw new ArgumentException("WrongID");
            }
            if (!NewEmail.Contains("@"))
            {
                throw new AggregateException("Wrong Email format");
            }
            EmpRepo.ChangeEmail(id,NewEmail);
        }

        public void ChangeName(int id, string NewName)
        {
            if (id < 1)
            {
                throw new ArgumentException("WrongID");
            }
            EmpRepo.ChangeName(id, NewName);
        }

        public void Create(Employee newEmp)
        {
            if (newEmp.ID < 1)
            {
                throw new ArgumentException("WrongID");
            }
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

        public double EmployeeAvargeSalary(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("WrongID");
            }
            Employee x=EmpRepo.GetOne(id);
            double avarge = 0;
            foreach (var item in x.Salaries)
            {
                avarge += item.BaseSalary;
            }
            return avarge / x.Salaries.Count();
        }

        public double EmployeeAvargeSalary(Employee emp)
        {
            if (emp.ID < 1)
            {
                throw new ArgumentException("WrongID");
            }
            Employee x = EmpRepo.GetOne(emp.ID);
            double avarge = 0;
            foreach (var item in x.Salaries)
            {
                avarge += item.BaseSalary;
            }
            return avarge / x.Salaries.Count();
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
