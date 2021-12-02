using DCQEB4_HFT_2021221.Models;
using DCQEB4_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCQEB4_HFT_2021221.Logic
{
    public class DepartmentLogic : IDepartmentLogic
    {
        IDepartmentRepository depRepo;
        IEmployeeRepository emprepo;
        ISalaryRepository salrepo;
        public DepartmentLogic(IDepartmentRepository departmentRepository,IEmployeeRepository employeeRepository,ISalaryRepository salaryRepository)
        {
            depRepo = departmentRepository;
            emprepo = employeeRepository;
            salrepo = salaryRepository;
        }

        public void Create(Department newDep)
        {
            //if (newDep.ID < 1)
            //{
            //    throw new ArgumentException("WrongID");
            //}
            if (newDep.DepartmentName.Length <= 3)
            {
                throw new ArgumentException("Name is invalid");
            }
            depRepo.Create(newDep);
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("WrongID");
            }
            depRepo.Delete(id);
        }

        public void Delete(Department delete)
        {
            if (delete.ID < 1)
            {
                throw new ArgumentException("WrongID");
            }
            depRepo.Delete(delete);
        }

        public IList<DepartmentCost> DepartmentCost()
        {
            var a = from x in salrepo.GetAll()
                    group x by new { x.Employee.DepartmentID,x.Employee.Department.DepartmentName } into qq
                    select new DepartmentCost(){ DepartmentName=qq.Key.DepartmentName,AvargeCost=qq.Average(x=>x.BaseSalary)};
            return a.ToList();
        }

        public IList<Department> GetAll()
        {
            return depRepo.GetAll().ToList();
        }

        public Department GetOne(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("WrongID");
            }
            return depRepo.GetOne(id);
        }

        public void Update(Department updatedDep)
        {
            depRepo.Update(updatedDep);
        }
        public IList<Employee> ListAllEmpForOneDep(int id)
        {
            var res = depRepo.GetOne(id);
            return res.Employees.ToList();
        }
        public IList<Salary> ListAllSalForOneEmp(int id)
        {
            var res = emprepo.GetOne(id);
            return res.Salaries.ToList();
        }
    }
}
